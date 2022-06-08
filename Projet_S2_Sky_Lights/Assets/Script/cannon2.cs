using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class cannon2 : MonoBehaviour
{
    
    
    public GameObject boulet;
    public GameObject embouchure;

    public Transform bouletorigine;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "contact")
        {
            tire();
        }
        
        if (collision.gameObject.name == "contacte")
        {
            tire();
        }
        print(collision.gameObject.name);
    }
    


    private GameObject b;

    void tire()
    {
        b = PhotonNetwork.Instantiate(this.boulet.name, bouletorigine.position, Quaternion.identity, 0);
        b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
        Debug.LogError("tire efectuer");
        
    }
}
