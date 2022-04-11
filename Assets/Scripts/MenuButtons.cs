using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public string mainScene = "main";
    public string statisticsScene = "stats";
    public string settingsScene = "settings";
    public string menuScene = "menu";
    public GameObject GameManager;
    public GameObject ClientManager;

    public void StartGame()
    {
        GameManager = Instantiate(GameManager);
        ClientManager = Instantiate(ClientManager);
        Client.instance.ConnectToServer();
        SceneManager.LoadScene(mainScene);

        
    }
    public void StatsButton()
    {
        SceneManager.LoadScene(statisticsScene);
    }
    public void settingButton()
    {
        SceneManager.LoadScene(settingsScene);
    }


    public void menuButton()
    {
         SceneManager.LoadScene(menuScene);
    }

    
}
