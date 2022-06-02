using System.Collections;
using UnityEngine;

public class GameManagerMenu : MonoBehaviour 
{
    public static GameManagerMenu GM;

    public KeyCode jump {get;set;}
    public KeyCode forward {get;set;}
    public KeyCode backward {get;set;}
    public KeyCode left {get;set;}
    public KeyCode right {get;set;}
    void Awake()
    {
        if(GM == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }
        jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey","Space"));
        forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey","W"));
        backward  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backward","S"));
        left  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftkey","A"));
        right  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightkey","D"));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
