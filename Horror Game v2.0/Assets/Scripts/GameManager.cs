using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject GamePause;
    [SerializeField] private GameObject player;

    private bool gameIsPaused;
    private bool gameIsStarted;
    void Start() {
        gameIsPaused = false;
        gameIsStarted = false;
        MainUI.SetActive(false);
        MainMenu.SetActive(true);
        GameOver.SetActive(false);
        GamePause.SetActive(false);
        player.SetActive(false);
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gamePause();
        }
        
    }
    internal void gameStart() {
        if (!gameIsStarted) {
            MainUI.SetActive(true);
            MainMenu.SetActive(false);
            GameOver.SetActive(false);
            GamePause.SetActive(false);
            player.SetActive(true);
            gameIsStarted = true;
        }
    }

    internal void gameEnd() {
        if (gameIsStarted && !gameIsPaused) {
            MainUI.SetActive(false);
            GameOver.SetActive(true);
            MainMenu.SetActive(false);
            GamePause.SetActive(false);
            player.SetActive(false);
            gameIsStarted = false;
        }
    }
    internal void gamePause() {
        if (gameIsStarted && !gameIsPaused) {
            MainUI.SetActive(false);
            GamePause.SetActive(true);
            player.SetActive(false);
            gameIsPaused = true;
        }else if (gameIsStarted && gameIsPaused) {
            MainUI.SetActive(true);
            GamePause.SetActive(false);
            player.SetActive(true);
            gameIsPaused = false;
        }

    }

    internal void gameQuit() {
        Application.Quit();
    }

    internal void gameRestart() {
        SceneManager.LoadScene("MainScene");
    }
}
