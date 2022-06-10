using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Batteaux : MonoBehaviourPunCallbacks
{
    public float vitesse = 60.0f;
    public float moveSpeed = 8000.0f;
    public Rigidbody rigidbodyBatteau;

    public Text vie;
    private int vieint = 20;
    private PhotonView view;
    
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        view.RPC("start",RpcTarget.Others);
        vie.text = "20 / "+ vieint;
    }

    // Update is called once per frame
    void Update()
    {
        avance();
        //ratation(1);
    }
    
    [PunRPC]
    void start()
    {
        
        view.RPC("bateau_mise_emplace",RpcTarget.Others,(this.transform.position,this.transform.rotation.y));
    }
    

    [PunRPC]
    void bateau_mise_emplace(Vector3 vector3,int angle)
    {
        this.transform.position = vector3;
        this.transform.eulerAngles = new Vector3(0, angle, 0);
    }

    //[PunRPC]
    void Ratation(int n)
    {
        this.transform.Rotate(new Vector3(0,n,0)* Time.deltaTime);
    }
    
    
    public void avance()
    {
        
            
        //var vDeplacement = Input.GetAxis("Vertical") *  vitesse *moveSpeed *2;
            
        //rigidbodyBatteau.velocity = (transform.forward * vDeplacement) + new Vector3(0, rigidbodyBatteau.velocity.y, 0);
            
        transform.Translate(Vector3.left*Time.deltaTime * vitesse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "contact"  )
        {
            vieint--;
            vie.text = "20 / "+ vieint;
        }
        
    }
}
