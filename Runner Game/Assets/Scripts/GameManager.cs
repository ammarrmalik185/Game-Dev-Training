using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject pauseUI;
    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            pauseGame();
        }
    }
    public void retryGame() {
        StaticValues.score = 0;
        StaticValues.gameIsEnded = false;
        SceneManager.LoadScene("defaultScene");
    }
    void pauseGame() {
        if (!StaticValues.gameIsEnded) {
            StaticValues.gameIsPaused = true;
            pauseUI.SetActive(true);
            StaticValues.gameIsRunning = false;
        }
    }
    public void continueGame() {
        if (!StaticValues.gameIsEnded) {
            StaticValues.gameIsPaused = false;
            pauseUI.SetActive(false);
            StaticValues.gameIsRunning = true;
        }
    }
}
