using UnityEngine;
using UnityEngine.SceneManagement;

namespace UserInterface
{
    /// <summary>
    /// the main menu functions.
    /// </summary>
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
}