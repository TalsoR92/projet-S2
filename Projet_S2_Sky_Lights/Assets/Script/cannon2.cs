using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class cannon2 : MonoBehaviour
{
    
    
    public GameObject boulet;

    public Transform bouletorigine;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    private PhotonView view;
    
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        timerIsRunning = true;
    }

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
    
    
    [PunRPC]
    void chamgement3()
    {
        timerIsRunning = false;
        timeRemaining = 10;
    }
    
    
    public void tire()
    {
        b = PhotonNetwork.Instantiate(this.boulet.name, bouletorigine.position, Quaternion.identity, 0);
        //b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
        b.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * 100000);
        Debug.LogError("tire efectuer");
        //Thread.Sleep(5000);
        timerIsRunning = false;
        timeRemaining = 10;
        view.RPC("chamgement3",RpcTarget.Others);
        
    }
}
