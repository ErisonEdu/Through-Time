using UnityEngine;
using UnityEngine.UI;

public class PlayerHudController : MonoBehaviour {
    
    [SerializeField]
    private LifeBarController[] lifeBar;
    [SerializeField]
    private BombBarController[] bombBar;

    [SerializeField]
    private Text textScore;

    public void updateLife(int lifes) {
        switch (lifes) {
            case 0:
                lifeBar[0].lifeUpdate(HeartState.EMPTY);
                lifeBar[1].lifeUpdate(HeartState.EMPTY);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 1:
                lifeBar[0].lifeUpdate(HeartState.ONE);
                lifeBar[1].lifeUpdate(HeartState.EMPTY);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 2:
                lifeBar[0].lifeUpdate(HeartState.TWO);
                lifeBar[1].lifeUpdate(HeartState.EMPTY);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 3:
                lifeBar[0].lifeUpdate(HeartState.THREE);
                lifeBar[1].lifeUpdate(HeartState.EMPTY);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 4:
                lifeBar[0].lifeUpdate(HeartState.FOUR);
                lifeBar[1].lifeUpdate(HeartState.EMPTY);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 5:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.EMPTY);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 6:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.ONE);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 7:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.TWO);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 8:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.THREE);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 9:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.FOUR);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 10:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.FULL);
                lifeBar[2].lifeUpdate(HeartState.EMPTY);
                break;
            case 11:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.FULL);
                lifeBar[2].lifeUpdate(HeartState.ONE);
                break;
            case 12:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.FULL);
                lifeBar[2].lifeUpdate(HeartState.TWO);
                break;
            case 13:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.FULL);
                lifeBar[2].lifeUpdate(HeartState.THREE);
                break;
            case 14:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.FULL);
                lifeBar[2].lifeUpdate(HeartState.FOUR);
                break;
            case 15:
                lifeBar[0].lifeUpdate(HeartState.FULL);
                lifeBar[1].lifeUpdate(HeartState.FULL);
                lifeBar[2].lifeUpdate(HeartState.FULL);
                break;
        }
    }

    public void updateBomb(int bombs) {
        switch (bombs) {
            case 0:
                bombBar[0].bombUpdate(BombState.EMPTY);
                bombBar[1].bombUpdate(BombState.EMPTY);
                bombBar[2].bombUpdate(BombState.EMPTY);
                break;
            case 1:
                bombBar[0].bombUpdate(BombState.FULL);
                bombBar[1].bombUpdate(BombState.EMPTY);
                bombBar[2].bombUpdate(BombState.EMPTY);
                break;
            case 2:
                bombBar[0].bombUpdate(BombState.FULL);
                bombBar[1].bombUpdate(BombState.FULL);
                bombBar[2].bombUpdate(BombState.EMPTY);
                break;
            case 3:
                bombBar[0].bombUpdate(BombState.FULL);
                bombBar[1].bombUpdate(BombState.FULL);
                bombBar[2].bombUpdate(BombState.FULL);
                break;
        }
    }

    public void setScore(string score) {
        textScore.text = score;
    }

    private void gameOver() {
        Debug.Log("Game Over");
    }

}