using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Batteaux_IA : MonoBehaviour
{

    public float vitesse = 60.0f;
    public float moveSpeed = 8000.0f;
    public Rigidbody rigidbodyBatteau;
    private GameObject cannon1;
    private GameObject cannon2;
    private int vieint = 10;
    // Start is called before the first frame update
    private PhotonView view;
    public GameObject boulet;
    private GameObject b;
    public Text vie;
    public bool V = false;
    public float timeRemaining2 = 5;
    void Start()
    {
          
        view = GetComponent<PhotonView>();
        view.RPC("startIA",RpcTarget.Others);
        //cannon1 = this.transform.Find("cannon2").gameObject;
        //cannon2 = this.transform.Find("cannon3").gameObject;
        view.RPC("start2IA",RpcTarget.Others);
        vie.text = vieint + " / 10";
            
            
        
    }
    
    [PunRPC]
    void start3IA(int n)
    {
        vieint = n;
        vie.text = vieint + " / 10";
    }
    
    
    [PunRPC]
    void start2IA()
    {
        view.RPC("start3IA",RpcTarget.Others,vieint);
    }
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "contact"  )
        {
            vieint--;
            
            vie.text = vieint + " / 10";
        }
        
    }

    public bool test = false;
    public float timeRemaining = 5;
    
    
    [PunRPC]
    void startIA()
    {
        view.RPC("bateau_mise_emplace_IA",RpcTarget.Others,(this.transform.position,this.transform.rotation.y));
    }
    
    [PunRPC]
    void bateau_mise_emplace_IA(Vector3 vector3,int angle)
    {
        this.transform.position = vector3;
        this.transform.eulerAngles = new Vector3(0, angle, 0);
    }
    
    [PunRPC]
    void rechargement()
    {
        test = false;
        timeRemaining = 5;
    }
    
    [PunRPC]
    public void Victory()
    {
        vie.text = "VICTORY";
        V = true;
        //Thread.Sleep(5000);
        
    }
    
    // Update is called once per frame
    
    void Update()
    {
        
        RaycastHit hit;
        Ray touchBoat = new Ray(transform.position,transform.forward);
        
        if (!V)
        {
            
            avancer();
            if (test == false)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    test = true;
                }
            }

            
            // forward => sur la droite du bateau
            Debug.Log("rip 1");

            if (test && !Physics.Raycast(touchBoat,150000000))
            {
                tourner(new Vector3(0,9,0));
            
                Debug.Log("rip 2");
            
            
                // timeRemaining = 10;
            }
            //Debug.DrawRay(transform.position,Vector3.forward * 500, Color.green);
        
            if (test && Physics.Raycast(touchBoat,1500000))
            {
                tire();
                view.RPC("rechargement",RpcTarget.Others);
                // tire1();
                test = false;
                timeRemaining = 5;
            }

            if (vieint <= 0)
            {
                print("Victory");
                view.RPC("Victory",RpcTarget.All);
            }
        }
        else
        {
            if (timeRemaining2 > 0)
            {
                timeRemaining2 -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("menu test V1");
            }
        }
        
        
        
        
        
        
        
        
        
    }



    void tire()
    {
        //view.RPC("startIA",RpcTarget.Others);
        
        b = PhotonNetwork.Instantiate(this.boulet.name, this.transform.position + Vector3.up * 120, Quaternion.identity, 0);
        b.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 300000 +gameObject.transform.right * 10000 );
        Debug.LogError("tire efectuer IA");
    }
    
    /*
    void tire1()
    {
        cannon1.SetActive(true);
    }
    
    void tire2()
    {
        cannon2.SetActive(true);
    }
    */
    void avancer()
    {
        transform.Translate(Vector3.left*Time.deltaTime * vitesse);
    }
    
    
    void tourner(Vector3 rotation)
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
    
}
