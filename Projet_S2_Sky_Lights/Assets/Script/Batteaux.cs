using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Batteaux : MonoBehaviourPunCallbacks
{
    public float vitesse = 1.0f;
    public float moveSpeed = 8000.0f;
    public Rigidbody rigidbodyBatteau;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        avance();
        
        
    }

    public void avance()
    {
        
            
        var vDeplacement = Input.GetAxis("Vertical") *  vitesse *moveSpeed *2;
            
        rigidbodyBatteau.velocity = (transform.forward * vDeplacement) + new Vector3(0, rigidbodyBatteau.velocity.y, 0);
            
        
    }
}
