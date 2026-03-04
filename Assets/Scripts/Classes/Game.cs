using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int state = 1;
    [SerializeField] int maxstates = 2;
    public static bool isPaused = false;

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

    public void NextState()
    {
        state ++;
        if (state > maxstates)
        {
            state = 1;
        }
    }

   /* public void ExecuteState()
    {
        if(state == 1)
        {
            RevealDirectionUI();
        }
        if(state == 2)
        {
            OnPlayerEnter();
        }
    }*/
}
