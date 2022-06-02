using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;
    async void Start()
    {
        menuPanel = transform.FindChild("Panel");
        menuPanel.gameObject.SetActive(false);
        waitingForKey = false;

        for (int i = 0 ; i < 5 ; i++)
        {
            if (menuPanel.GetChild(i).name == "ForwardKey")
                menuPanel.GetChild(i).GetComponent<Text>().text = GameManagerMenu.GM.forward.ToString();
            else if (menuPanel.GetChild(i).name == "BackwardKey")
                menuPanel.GetChild(i).GetComponent<Text>().text = GameManagerMenu.GM.backward.ToString();
            else if (menuPanel.GetChild(i).name == "LeftKey")
                menuPanel.GetChild(i).GetComponent<Text>().text = GameManagerMenu.GM.left.ToString();
            else if (menuPanel.GetChild(i).name == "RightKey")
                menuPanel.GetChild(i).GetComponent<Text>().text = GameManagerMenu.GM.right.ToString();
            else if (menuPanel.GetChild(i).name == "JumpKey")
                menuPanel.GetChild(i).GetComponent<Text>().text = GameManagerMenu.GM.jump.ToString();
        }


    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(true);
        else if(Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(false);
    }

    void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if(!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while(!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey();

        switch(keyName)
        {
            case "forward":
                GameManagerMenu.GM.forward = newKey;
                buttonText.text = GameManagerMenu.GM.forward.ToString();
                PlayerPrefs.SetString("forwardKey", GameManagerMenu.GM.forward.ToString());
                break;
            case "backward":
                GameManagerMenu.GM.backward = newKey;
                buttonText.text = GameManagerMenu.GM.backward.ToString();
                PlayerPrefs.SetString("backwardKey", GameManagerMenu.GM.backward.ToString());
                break;
            case "left":
                GameManagerMenu.GM.left = newKey;
                buttonText.text = GameManagerMenu.GM.left.ToString();
                PlayerPrefs.SetString("leftKey", GameManagerMenu.GM.left.ToString());
                break;
            case "right":
                GameManagerMenu.GM.right = newKey;
                buttonText.text = GameManagerMenu.GM.right.ToString();
                PlayerPrefs.SetString("rightKey", GameManagerMenu.GM.right.ToString());
                break;
            case "jump":
                GameManagerMenu.GM.jump = newKey;
                buttonText.text = GameManagerMenu.GM.jump.ToString();
                PlayerPrefs.SetString("jumpKey", GameManagerMenu.GM.jump.ToString());
                break;
            
        }
        yield return null;
    }

}
