using System.Collections;
using System.Collections.Generic;
//using System.Threading;
using Photon.Pun;
using UnityEngine;

public class cannon : MonoBehaviourPunCallbacks
{


    public GameObject boulet;
    public GameObject embouchure;

    public Transform bouletorigine;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning == false)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerIsRunning = true;
            }
        }
    }

    public void ChangeState()
    {
        if (true == gameObject.activeInHierarchy && timerIsRunning)
        {
            tire();
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        //Debug.LogError("contacte connon");
        //tire();
        if (collision.gameObject.tag == "Player" && timerIsRunning )
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

    public void tire()
    {
        b = PhotonNetwork.Instantiate(this.boulet.name, bouletorigine.position, Quaternion.identity, 0);
        //b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
        b.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * 100000);
        Debug.LogError("tire efectuer");
        //Thread.Sleep(5000);
        timerIsRunning = false;
        timeRemaining = 10;
        
    }
    
    
}
