using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;


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

    public AudioClip sonMarcher;
    public AudioClip sonCourir;
    public AudioClip sonSauter;



    private GameObject b;
    public GameObject boulet;
    public GameObject boulet2;

    public Transform bouletorigine;
    
    
    public Rigidbody rigidbodyPerso;
    
    public GameObject pere;
    
    public GameObject spaunw;
    //public Animation animations;
    
    public GameObject coli;
    
    void Start()
    {
        
        rigidbodyPerso = GetComponent<Rigidbody>(); 
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
        
        //this.transform.parent = pere.transform;

    }
    
    
    
    
    bool conctact()
    {
        //return Physics.CheckCapsule(_collider.bounds.center, new Vector3(_collider.bounds.center.x, _collider.bounds.min.y - 0.1f, _collider.bounds.center.z),0.59f);

        
        //Debug.LogError(Physics.Raycast(transform.position, transform.up, out hit, -1000), this);
        //return Physics.Raycast(transform.position, transform.up, out hit, -1000);
        Ray ray = new Ray(transform.position + Vector3.up *5, Vector3.down);
        if (Physics.Raycast(ray,22))
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
        //Ray ray2 = new Ray(transform.position + Vector3.up * 55, Vector3.forward);
        Ray ray2 = new Ray(transform.position + Vector3.up * 45, transform.TransformDirection(Vector3.forward));
        int layer_mask = LayerMask.GetMask("cannon");
        
        
        
        
        if(Physics.Raycast(ray2, out hit, 75, layer_mask, QueryTriggerInteraction.Ignore))
        {
            
            if (hit.transform.name == "cannon2")
            {
                //hit.transform.SetActive(false);
                Debug.LogError("depuit cannon2");
            }
            GameObject coli2 = PhotonNetwork.Instantiate(this.coli.name, hit.point, Quaternion.identity, 0);
            //coli2.transform.parent = pere.transform;
            print(hit.transform.name +" traverse le rayon.");
            print("La distance est de " + hit.distance);
            //coli2.transform.position = hit.point;
            return true;
        }
        
        
        
        
        // if (Physics.Raycast(ray2,out hit,75/*,layer_mask*/))
        // {
        //     if (hit.transform.name == "cannon2")
        //     {
        //         b = PhotonNetwork.Instantiate(this.boulet.name,  new Vector3(267, 195, -4745), Quaternion.identity, 2);
        //         b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
        //         Debug.LogError("depuit cannon2");
        //     }
        //     else if (hit.transform.name == "cannon3")
        //     {
        //         b = PhotonNetwork.Instantiate(this.boulet2.name,  new Vector3(267, 195, -4416), Quaternion.identity, 1);
        //         b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
        //         Debug.LogError("depuit cannon3");
        //     }
        //     //else
        //     //{
        //         //b = PhotonNetwork.Instantiate(this.boulet.name,  new Vector3(267, 195, -4745), Quaternion.identity, 2);
        //         //b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
        //         //Debug.LogError("par defaut");
        //     //}
        //     Debug.LogError(hit.transform.name);
        //     //b = PhotonNetwork.Instantiate(this.boulet.name, bouletorigine.position, Quaternion.identity, 0);
        //     //b.GetComponent<Rigidbody>().AddForce(bouletorigine.forward * 1000);
        //     return true;
        // }
        // else
        // {
        //     Debug.LogError(hit.transform.name);
        // }

        return false;

    }
    
    
    private void Update()
    {
        
        if (photonView.IsMine)
        {
            Debug.DrawRay(transform.position + Vector3.up *5,Vector3.down*50, Color.green);
            //Debug.DrawRay(transform.position + Vector3.up *55,Vector3.forward*75, Color.red);
            Debug.DrawRay(transform.position + Vector3.up *45,transform.TransformDirection(Vector3.forward)*75, Color.red);
            ProcessInput();
        }

        //if (gameObject.transform.position.y < 300)
        //{
        //    this.gameObject.transform.position = spaunw.transform.position;
        //}
        
    }



    public void ProcessInput()
    {
        // Déplacement personage
        if (Input.GetKey(avancer))
        {
            //var vDeplacement = Input.GetAxis("Vertical") * moveSpeed *20;
            //animations.Play("avancer");
            var vDeplacement = Input.GetAxis("Vertical") * moveSpeed *2;
            
            rigidbodyPerso.velocity = (transform.forward * vDeplacement) + new Vector3(0, rigidbodyPerso.velocity.y, 0);
            //rigidbodyPerso.AddRelativeForce(0, 0, vDeplacement ); 
            
            //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * 2);
            
            //GetComponent<AudioSource>().PlayOneShot(sonMarcher);
        }
        if (Input.GetKey(reculer))
        {
            var vDeplacement = Input.GetAxis("Vertical") * moveSpeed ;
            //rigidbodyPerso.AddRelativeForce(0, 0, -vDeplacement ); 
            rigidbodyPerso.velocity = (transform.forward * vDeplacement) + new Vector3(0,(-1)*rigidbodyPerso.velocity.y, 0);
            
            //transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            //GetComponent<AudioSource>().Play(sonMarcher);
        } 
        if (Input.GetKey(droite))
        {
            //var vDeplacement = Input.GetAxis("Horizontal") * moveSpeed;
            //rigidbodyPerso.AddRelativeForce(vDeplacement, 0, 0 ); 
            //rigidbodyPerso.velocity = (transform.forward * vDeplacement) + new Vector3(rigidbodyPerso.velocity.x, 0, 0);
            
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            //GetComponent<AudioSource>().Play(sonMarcher);
        }
        if (Input.GetKey(gauche))
        {
            //var vDeplacement = Input.GetAxis("Horizontal") * moveSpeed;
            //rigidbodyPerso.AddRelativeForce(-vDeplacement, 0, 0 ); 
            //rigidbodyPerso.velocity = (transform.forward * vDeplacement) + new Vector3( (-1)*rigidbodyPerso.velocity.x, 0, 0);
            
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            //GetComponent<AudioSource>().Play(sonMarcher);
        }
        if (Input.GetKeyDown(sauter) && conctact() )
        {
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = vecsauter.y;

            gameObject.GetComponent<Rigidbody>().velocity = vecsauter ;
            GetComponent<AudioSource>().PlayOneShot(sonSauter);


            //transform.Translate(0,1.2f,0);
        }

        // if (Input.GetKeyDown(avancer) || Input.GetKeyDown(reculer) || Input.GetKeyDown(droite) || Input.GetKeyDown(gauche))
        // {
        //      GetComponent<AudioSource>().PlayOneShot(sonMarcher);
        // }
        // else
        // {
        //     GetComponent<AudioSource>().Stop();
        // }
    

        


        if (Input.GetKeyDown(KeyCode.A) )
        {
            if (conctactcannon())
            {
                Debug.LogError("tire cannon");
            }
            else
            {
                Debug.LogError("ne tire pas");
            }
        }
        // Rotation avec souris
        direction = new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed;
        transform.Rotate(direction);

        
    
    }

}
