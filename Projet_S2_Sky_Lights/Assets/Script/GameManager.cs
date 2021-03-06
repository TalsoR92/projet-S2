using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using Photon.Pun.Demo.PunBasics;
public class GameManager : MonoBehaviourPunCallbacks
{
    
    public GameObject playerPrefab;
    public GameObject spaunw;
    public GameObject pere;
    public GameObject batteauxPrefab;
    private GameObject personage;
    private GameObject batteaux;
    private PhotonView view;
    public float vitesse = 40.0f;
    
    
    
    
    private Batteaux Script;
    
    //public Text vie;
    void Start()
    {
        
        
        //batteaux = PhotonNetwork.Instantiate(this.batteauxPrefab.name, new Vector3(263,498,-4579), Quaternion.identity, 0);
        
        //PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(389, 132, -4582), Quaternion.identity, 0);
        //PhotonNetwork.Instantiate(this.playerPrefab.name, spaunw.transform.position, Quaternion.identity, 0);
        personage = PhotonNetwork.Instantiate(this.playerPrefab.name, spaunw.transform.position, Quaternion.identity, 0);
        //if (batteaux == null)
        //{
        //    personage = PhotonNetwork.Instantiate(this.playerPrefab.name,new Vector3(263,498,-4579), Quaternion.identity, 0);
        //}
        //else
        //{
        //    personage = PhotonNetwork.Instantiate(this.playerPrefab.name,batteaux.transform.position, Quaternion.identity, 0);
        //}
        
        //personage.transform.parent = batteaux.transform;
        //personage.transform.parent = pere.transform;
        //vie.text = "20 / 20";
        view = GetComponent<PhotonView>();
        /*
        view.RPC("startpersonage",RpcTarget.OthersBuffered,personage);
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            Debug.LogError(p.UserId);
        }
        */
        Script = pere.GetComponent<Batteaux>();
    }

    [PunRPC]
    void startpersonage(GameObject p)
    {
        
        p.transform.parent = pere.transform;
        
    }
    void Update()
    {
        avance();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
        //Debug.LogError(transform.position.y);
        if (personage.transform.position.y < -65)
        {
            Debug.LogError("teleportation");
            this.personage.transform.position = spaunw.transform.position;
            //this.personage.transform.position = batteaux.transform.position;
        }
        if (Input.GetKey(KeyCode.D) )
        {
            pere.transform.Rotate(new Vector3(0,-8,0)* Time.deltaTime);
            
            //view.RPC("Ratation",RpcTarget.All,-2* Time.deltaTime);
            //view.RPC("start",RpcTarget.Others);
            view.RPC("bateau_mise_emplace2",RpcTarget.Others,(pere.transform.position,pere.transform.rotation.y));
        }
        if (Input.GetKey(KeyCode.F) )
        {
            pere.transform.Rotate(new Vector3(0,8,0)* Time.deltaTime);
            //view.RPC("Ratation",RpcTarget.All,2* Time.deltaTime);
            //view.RPC("start",RpcTarget.Others);
            view.RPC("bateau_mise_emplace2",RpcTarget.Others,(pere.transform.position,pere.transform.rotation.y));
        }
    }
    
    public void avance()
    {
        Script.avance(personage);
        //Script.
        //transform.Translate(Vector3.left*Time.deltaTime * vitesse);
        //pere.transform.Translate(pere.transform * (-1)  * vitesse / 50);
        //personage.transform.Translate(pere.transform.rotation.eulerAngles * (-1)  * vitesse / 20);
    }
    
    
    
    [PunRPC]
    void bateau_mise_emplace2(Vector3 vector3,int angle)
    {
        pere.transform.position = vector3;
        pere.transform.eulerAngles = new Vector3(0, angle, 0);
    }
    
    [PunRPC]
    void Ratation(int n)
    {
        pere.transform.Rotate(new Vector3(0,n,0)* Time.deltaTime);
    }

    public void OnPlayerEnterRoom(Player other)
    {
        print(other.NickName + " s'est connect?? !");
    }
    
    public void OnPlayerLeftRoom(Player other)
    {
        print(other.NickName + " s'est d??connect?? !");
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("launcherScene");
    }
    
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
    
    
}
