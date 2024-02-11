using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Scenes/ForestersRun");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}