using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool isPaused;

    public GameObject pauseMenu; //Menu for pausing

    // Update is called once per frame
    void Start()
    {
        //Makes sure menu isnt active at start
        pauseMenu.SetActive(false);
    }

    //Unpauses the game
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //isPaused = false;
    }

    //Pauses the game
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        // isPaused = true;
    }
}
