using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;


//using Photon.Pun.Demo.PunBasics;

public class Personnage : MonoBehaviourPunCallbacks
{
    public float angle;
    public float moveSpeed = 100.0f;
    public float rotateSpeed = 1800.0f;
    public Vector3 vecsauter;

    CapsuleCollider _collider;
    
    public string avancer;
    public string reculer;
    public string droite;
    public string gauche;
    public string sauter;

    public string action;

    private Vector3 direction = new Vector3(0,0,0);
    
    
    
    
    private GameObject b;
    public GameObject boulet;

    public Transform bouletorigine;
    /*
    void Start()
    {
        CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();


        if (_cameraWork != null)
        {
            if (photonView.IsMine)
            {
                _cameraWork.OnStartFollowing();
            }
        }
        else
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork de playerPrefab inexistant.", this);
        }
    }
    */

    void Start()
    {
         Physics.gravity = new Vector3(0, -200.00F, 0);

         _collider = gameObject.GetComponent<CapsuleCollider>();
         
         
         
         
         CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();


         if (_cameraWork != null)
         {
             if (photonView.IsMine)
             {
                 _cameraWork.OnStartFollowing();
             }
         }
         else
         {
             Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
         }
         
    }

    bool conctact()
    {
        //return Physics.CheckCapsule(_collider.bounds.center, new Vector3(_collider.bounds.center.x, _collider.bounds.min.y - 0.1f, _collider.bounds.center.z),0.59f);

        
        //Debug.LogError(Physics.Raycast(transform.position, transform.up, out hit, -1000), this);
        //return Physics.Raycast(transform.position, transform.up, out hit, -1000);
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray,50))
        {
            return true;
        }

        return false;

    }
    
    
    bool conctactcannon()
    {
        //Debug.LogError("tire cannon2");
        RaycastHit hit;
        //int layer_mask = LayerMask.GetMask("cannon");
        Ray ray2 = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray2,out hit,75/*,layer_mask*/))
        {
            b = PhotonNetwork.Instantiate(this.boulet.name, bouletorigine.position, Quaternion.identity, 0);
            b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
            return true;
        }

        return false;

    }
    
    
    private void Update()
    {
        
        if (photonView.IsMine)
        {
            Debug.DrawRay(transform.position,Vector3.down*50, Color.green);
            Debug.DrawRay(transform.position,Vector3.forward*75, Color.red);
            ProcessInput();
        }
    }
    
    

    public void ProcessInput()
    {
        // Déplacement personage
        if (Input.GetKey(avancer))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * 2);
        }
        if (Input.GetKey(reculer))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        } 
        if (Input.GetKey(droite))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(gauche))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyDown(sauter) && conctact() )
        {
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = vecsauter.y;

            gameObject.GetComponent<Rigidbody>().velocity = vecsauter;
            
            
            //transform.Translate(0,1.2f,0);
        }
        if (Input.GetKeyDown(KeyCode.A) && conctactcannon() )
        {
            
            
            
            
            Debug.LogError("tire cannon");
        }
        // Rotation avec souris
        direction = new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed;
        transform.Rotate(direction); 
    }
}
