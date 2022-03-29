using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    public static NetworkUI instance;
    public TMPro.TMP_InputField usernameField;

    //singleton implentation only allows on one instance
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // should not destory client manager not the canvas
            //NEED TO FIX
            //DontDestroyOnLoad(transform.root.gameObject);
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
        Client.instance.ConnectToServer();
        // not need instace created when start button pressed
        
    }

}
