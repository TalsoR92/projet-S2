using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public string leveToLoad;
    public GameObject settingsWindow;

    public GameObject settingsKeys;

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void JoinRoomButton()
    {
        // Debug.Log("walah faut que ca marche");
        //SceneManager.LoadScene(leveToLoad);
    }
    
    public void SettingsButton2()
    {
        settingsKeys.SetActive(true);
        
    }
    public void CloseSettingsWindow2()
    {
        settingsKeys.SetActive(false);
    }
}
