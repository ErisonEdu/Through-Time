using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    private PlayerHudController playerHudController;
    [SerializeField]
    private SoundController soundController;

    [SerializeField]
    private Image painelGameOver;
    [SerializeField]
    private Text scoreGameover;

    [SerializeField]
    private PortalController[] portais;
    
    private bool parte1;
    private bool ativouParte1;
    private bool parte2;
    private bool ativouParte2;
    private bool parte3;
    private bool ativouParte3;
    private bool parte4;
    private bool ativouParte4;

    private int score;
    private bool isGameover;

    void Awake() {
        parte1 = false;
        parte2 = false;
        parte3 = false;
        parte4 = false;
        ativouParte1 = false;
        ativouParte2 = false;
        ativouParte3 = false;
        ativouParte4 = false;

        isGameover = false;
    }
    
    void Update() {
        if (isGameover) {
            if (!painelGameOver.IsActive()) {
                painelGameOver.gameObject.SetActive(true);
                scoreGameover.text = Utilidades.formatarZerosEsquerda(score);
                soundController.temaStop();
                soundController.gameoverPlay();
            }
        } else {
            if (parte1 && !ativouParte1) {
                ativouParte1 = true;
                ativarParte1();
            }

            if (parte2 && !ativouParte2) {
                ativouParte2 = true;
                ativarParte2();
            }

            if (parte3 && !ativouParte3) {
                ativouParte3 = true;
                ativarParte3();
            }

            if (parte4 && !ativouParte4) {
                ativouParte4 = true;
                ativarParte4();
            }
        }
    }

    private void newGame() {
        score = 0;
    }

    public void addPoints(int points) {
        score += points;
        playerHudController.setScore(Utilidades.formatarZerosEsquerda(score));
    }

    public void setLife(int life) {
        playerHudController.updateLife(life);

        if (life <= 0) {
            SetGameover(true);
        }
    }

    public void setBomb(int bomb) {
        playerHudController.updateBomb(bomb);
    }

    private void SetGameover(bool isGameover) {
        this.isGameover = isGameover;
    }

    private void ativarParte1() {
        Debug.Log("Teste 1");

        portais[0].abrirPortal();
        portais[1].abrirPortal();
        portais[2].abrirPortal();
    }

    private void ativarParte2() {

    }

    private void ativarParte3() {

    }

    private void ativarParte4() {

    }

    public void setParte1(bool parte1) {
        Debug.Log("Teste 2");
        this.parte1 = parte1;
    }

    public void setParte2(bool parte2) {
        this.parte2 = parte2;
    }

    public void setParte3(bool parte3) {
        this.parte3 = parte3;
    }

    public void setParte4(bool parte4) {
        this.parte4 = parte4;
    }

    public void setAtivarParte1(bool ativouParte1) {
        Debug.Log("Teste 3");
        this.ativouParte1 = ativouParte1; ;
    }

    public void setAtivarParte2(bool ativouParte2) {
        this.ativouParte2 = ativouParte2;
    }

    public void setAtivarParte3(bool ativouParte3) {
        this.ativouParte3 = ativouParte3;
    }

    public void setAtivarParte4(bool ativouParte4) {
        this.ativouParte4 = ativouParte4;
    }

}