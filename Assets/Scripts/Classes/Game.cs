using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public TurnManager turnmanager;

    public static bool isPaused = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Game")
        {
            turnmanager.ExecuteState(1);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        AudioListener.pause = isPaused;
        if(Time.timeScale == 0)
        {
            Debug.Log("Paused");
        }
        else if(Time.timeScale == 1)
        {
            Debug.Log("Unpaused");
        }
    }
}
