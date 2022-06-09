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
        personage.transform.parent = pere.transform;
        //vie.text = "20 / 20";
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
        //Debug.LogError(transform.position.y);
        if (personage.transform.position.y < 300)
        {
            Debug.LogError("teleportation");
            this.personage.transform.position = spaunw.transform.position;
            //this.personage.transform.position = batteaux.transform.position;
        }
    }
    

    public void OnPlayerEnterRoom(Player other)
    {
        print(other.NickName + " s'est connecté !");
    }
    
    public void OnPlayerLeftRoom(Player other)
    {
        print(other.NickName + " s'est déconnecté !");
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
