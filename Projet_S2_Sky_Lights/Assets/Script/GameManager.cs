using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.PunBasics;
public class GameManager : MonoBehaviourPunCallbacks
{
    
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        
        /*CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();


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
        */
        // verifier que le jouer est connecter

        PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(180, 300, 140), Quaternion.identity, 0);

    }

    // Update is called once per frame
    void Update()
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
