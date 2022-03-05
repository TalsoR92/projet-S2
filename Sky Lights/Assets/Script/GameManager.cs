using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject playerPrefab;
    
    
    
    void Start()
    {
        // verifier que le jouer est connecter

        PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0, 2, 0), Quaternion.identity, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
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
        SceneManager.LoadScene("MylauncherScene");
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
