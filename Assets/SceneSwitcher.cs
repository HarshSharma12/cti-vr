using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject helpScreen;

    public void GotoMainScene()
    {
        Debug.Log("Switching to Game");
        SceneManager.LoadScene(1);
    }

    public void GotoMenuScene()
    {
        mainMenu.SetActive(false);
        helpScreen.SetActive(true);
    }

    public void GotoMainMenu()
    {
        helpScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Exitgame()
    {
        Application.Quit();
    }
}