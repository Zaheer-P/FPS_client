using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    public static NetworkUI instance;
    public static GameObject mainMenu;
    public TMPro.TMP_InputField usernameField;
    public TMPro.TMP_InputField IPField;

    //singleton implentation only allows on one instance
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != this)
        {
            Debug.LogWarning("instace already exists, destory");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        usernameField.interactable = false;
        IPField.interactable = false;
        
        // not need instace created when start button pressed
        
    }

}
