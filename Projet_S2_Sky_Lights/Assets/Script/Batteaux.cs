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
    }
    
    [PunRPC]
    void start()
    {
        
        view.RPC("bateau_mise_emplace",RpcTarget.Others,(this.transform.position));
    }
    

    [PunRPC]
    void bateau_mise_emplace(int x1,int y1,int z1)
    {
        this.transform.position = new Vector3(x1, y1, z1);
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
