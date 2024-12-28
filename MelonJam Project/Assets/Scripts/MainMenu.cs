using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;

    public void PlayGame()
    {
        sceneToLoad = "Game";
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.Log("Scene name is empty or not set.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
