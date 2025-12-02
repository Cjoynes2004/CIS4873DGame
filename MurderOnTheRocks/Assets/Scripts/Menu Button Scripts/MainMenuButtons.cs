using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{   
    public void PlayGame()
    {
        SceneManager.LoadScene(2); // loads scene at index 2(level 1)
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is closing...");
    }

    public void ControlMenu()
    {
        SceneManager.LoadScene(1); // loads scene at index 1(Controls Screen)
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);  // loads scene at index 0(Main Menu)
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

