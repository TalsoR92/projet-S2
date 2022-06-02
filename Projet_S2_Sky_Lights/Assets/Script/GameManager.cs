using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
//using Photon.Pun.Demo.PunBasics;
public class GameManager : MonoBehaviourPunCallbacks
{
    
    public GameObject playerPrefab;
    public GameObject spaunw;
    public GameObject pere;

    private GameObject personage;
    void Start()
    {
        
        //PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(389, 132, -4582), Quaternion.identity, 0);
        //PhotonNetwork.Instantiate(this.playerPrefab.name, spaunw.transform.position, Quaternion.identity, 0);
        personage = PhotonNetwork.Instantiate(this.playerPrefab.name, spaunw.transform.position, Quaternion.identity, 0);
        personage.transform.parent = pere.transform;
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
