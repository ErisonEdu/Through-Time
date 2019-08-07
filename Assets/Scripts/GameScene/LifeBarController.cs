using UnityEngine;
using UnityEngine.UI;

public enum HeartState {
    EMPTY, ONE, TWO, THREE, FOUR, FULL
}

public class LifeBarController : MonoBehaviour {

    [SerializeField]
    private Image[] hearts;

    private HeartState heartState;

    void Awake() {
        newGame();
    }

    private void newGame() {
        heartState = HeartState.FULL;
    }

    public void lifeUpdate(HeartState heartState) {
        this.heartState = heartState;

        lifeUpdate();
    }

    private void lifeUpdate() {
        clearAll();

        switch (heartState) {
            case HeartState.EMPTY:
                hearts[0].gameObject.SetActive(true);
                break;
            case HeartState.ONE:
                hearts[1].gameObject.SetActive(true);
                break;
            case HeartState.TWO:
                hearts[2].gameObject.SetActive(true);
                break;
            case HeartState.THREE:
                hearts[3].gameObject.SetActive(true);
                break;
            case HeartState.FOUR:
                hearts[4].gameObject.SetActive(true);
                break;
            case HeartState.FULL:
                hearts[5].gameObject.SetActive(true);
                break;
        }
    }

    private void clearAll() {
        foreach (Image img in hearts) {
            img.gameObject.SetActive(false);
        }
    }

}