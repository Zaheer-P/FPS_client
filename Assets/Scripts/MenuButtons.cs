using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public string mainScene = "main";
    public string statisticsScene = "stats";
    public string settingsScene = "settings";
    public string menuScene = "menu";
    public void StartGame()
    {
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
