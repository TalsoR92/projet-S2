using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class cannon : MonoBehaviourPunCallbacks
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

    public void ChangeState()
    {
        if (true == gameObject.activeInHierarchy)
        {
            tire();
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        //Debug.LogError("contacte connon");
        //tire();
        if (collision.gameObject.tag == "Player")
        {
            tire();
        }
        
        //if (collision.gameObject.name == "contacte")
        //{
        //    tire();
        //}
        print(collision.gameObject.name);
    }
    


    private GameObject b;

    void tire()
    {
        b = PhotonNetwork.Instantiate(this.boulet.name, bouletorigine.position, Quaternion.identity, 0);
        //b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
        b.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * 100000);
        Debug.LogError("tire efectuer");
        
    }
    
    
}
