using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class cannon : MonoBehaviourPunCallbacks
{


    public GameObject boulet;

    public Transform bouletorigine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject b;

    void tire()
    {
        b = PhotonNetwork.Instantiate(this.boulet.name, bouletorigine.position, Quaternion.identity, 0);
        b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
    }
    
    
}
