using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject settingsWindow;
    public void QuitButton()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    public void JoinRoomButton()
    {
        Debug.Log("walah faut que ca marche");
    }
    
}
