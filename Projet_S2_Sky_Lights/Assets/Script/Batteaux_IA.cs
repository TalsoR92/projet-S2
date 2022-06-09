using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor.UIElements;
using UnityEngine;

public class Batteaux_IA : MonoBehaviour
{

    public float vitesse = 60.0f;
    public float moveSpeed = 8000.0f;
    public Rigidbody rigidbodyBatteau;
    private GameObject cannon1;
    private GameObject cannon2;
    private int vieint = 20;
    // Start is called before the first frame update
    private PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        cannon1 = this.transform.Find("cannon2").gameObject;
        cannon2 = this.transform.Find("cannon3").gameObject;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "contact"  )
        {
            vieint--;
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        avancer();
        if (vieint <= 0)
        {
            print("Victory");
            view.RPC("Victory",RpcTarget.Others);
        }
    }

    void tire1()
    {
        cannon1.SetActive(true);
    }
    
    void tire2()
    {
        cannon2.SetActive(true);
    }
    void avancer()
    {
        transform.Translate(Vector3.left*Time.deltaTime * vitesse);
    }
    
    
    void tourner(Vector3 rotation)
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
    
}
