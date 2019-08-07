using UnityEngine;
using UnityEngine.UI;

public enum BombState {
    EMPTY, FULL
}

public class BombBarController : MonoBehaviour {

    [SerializeField]
    private Image[] bombs;

    private BombState bombState;

    void Awake() {
        newGame();
    }

    private void newGame() {
        bombState = BombState.EMPTY;
    }

    public void bombUpdate(BombState bombState) {
        this.bombState = bombState;

        bombUpdate();
    }

    private void bombUpdate() {
        clearAll();

        switch (bombState) {
            case BombState.EMPTY:
                bombs[0].gameObject.SetActive(true);
                break;
            case BombState.FULL:
                bombs[1].gameObject.SetActive(true);
                break;
        }
    }

    private void clearAll() {
        foreach (Image img in bombs) {
            img.gameObject.SetActive(false);
        }
    }

}