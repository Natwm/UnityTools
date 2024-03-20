using Blacktool.Enum;
using Blacktool.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blacktool.UI.Menu
{
    /// <summary>
    /// This class is used to pause the current game
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        GameObject pauseMenuUI;

        static bool WantsToQuit()
        {
            Debug.Log("Player prevented from quitting.");
            return false;
        }

        // Start is called before the first frame update
        void Start()
        {
            pauseMenuUI = GameObject.Find("PauseMenu");
            pauseMenuUI.SetActive(false);
            Debug.Log(GameStatus.PAUSED);
        }

        /// <summary>
        /// Resume the current game
        /// </summary>
        public void resume()
        {
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenuUI.SetActive(false);
            Debug.Log("Resume");
            Time.timeScale = 1;
            GameManager.Instance.Status = GameStatus.RUNNING;
        }

        /// <summary>
        /// Quit the application
        /// </summary>
        public void OnApplicationQuit()
        {
            Debug.Log("Quit");
            Application.wantsToQuit += WantsToQuit;
            Application.Quit();
        }

        /// <summary>
        /// Return to the main menu
        /// </summary>
        public void toMenu()
        {
            SceneManager.LoadScene(0);
        }

        private void Update()
        {
            if (Input.GetButton("Pause"))
            {
                pauseMenuUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                GameManager.Instance.Status = GameStatus.PAUSED;
                Time.timeScale = 0;
            }
        }
    }
}