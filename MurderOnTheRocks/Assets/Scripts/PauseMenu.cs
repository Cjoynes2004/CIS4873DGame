using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused = false;

    void Start()
    {
        // Make sure game starts with mouse locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;

        // Lock mouse again
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;

        // Unlock mouse so buttons work
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        // Ensure time is normal
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
}
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
