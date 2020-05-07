using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    States controls;
    States gameStates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameStates)
        {
            case States.gameOn:
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                break;

            case States.gamePaused:
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameStates == States.gameOn)
            {
                gameStates = States.gamePaused;
            }

            else { gameStates = States.gameOn; }
        }
    }

    enum States
    {
        gameOn,
        gamePaused,
    }

    public void Resume()
    {
        gameStates = States.gameOn;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
