using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Icypeak.Orbit.Scene
{
    public class ChooseGameMode : MonoBehaviour
    {
        public void GoToDestroyMode()
        {
            SceneManager.LoadScene("CatchMode");
        }

        public void GoToSurviveMode()
        {
            SceneManager.LoadScene("DodgeMode");
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
