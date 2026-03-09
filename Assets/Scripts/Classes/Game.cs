using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public int state = 1;
    [SerializeField] int maxstates = 2;
    public static bool isPaused = false;

    [SerializeField] List<Detector> detectors = new List<Detector>();
    [SerializeField] GameObject dirmen;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Game")
        {
            ExecuteState(state);
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

    public void NextState()
    {
        state ++;
        if (state > maxstates)
        {
            state = 1;
        }
        ExecuteState(state);
    }

    public void ExecuteState(int st)
    {
        if(st == 1)
        {
            dirmen.SetActive(true);
            foreach (Detector detector in detectors)
            {
                detector.moveselection = true;
            }
        }
        else if (st == 2)
        {
            dirmen.SetActive(false);
            foreach (Detector detector in detectors)
            {
                detector.moveselection = false;
            }
            Debug.Log("State 2");
        }
    }
}
