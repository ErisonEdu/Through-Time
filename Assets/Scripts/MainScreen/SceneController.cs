using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void buttonStart() {
        startGame();
    }

    public void buttonExit() {
        exitGame();
    }

    public void gameToMainScreen() {
        SceneManager.LoadSceneAsync("MainScreen");
    }

    private void startGame() {
        SceneManager.LoadScene("GameScene");
    }

    private void exitGame() {
        Application.Quit();
    }

    public void gameToGame() {
        SceneManager.LoadSceneAsync("GameScene");
    }

}