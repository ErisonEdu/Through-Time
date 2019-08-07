using UnityEngine;

public class SoundController : MonoBehaviour {

    [SerializeField]
    private AudioSource gameoverAudio;
    [SerializeField]
    private AudioSource danoAudio;
    [SerializeField]
    private AudioSource puloAudio;
    [SerializeField]
    private AudioSource temaAudio;
    [SerializeField]
    private AudioSource tiroAudio;

    public void gameoverPlay() {
        gameoverAudio.Play();
    }

    public void danoPlay() {
        danoAudio.Play();
    }

    public void puloPlay() {
        puloAudio.Play();
    }

    public void temaPlay() {
        temaAudio.Play();
    }

    public void tiroPlay() {
        tiroAudio.Play();
    }

    public void gameoverStop() {
        gameoverAudio.Stop();
    }

    public void danoStop() {
        danoAudio.Stop();
    }

    public void puloStop() {
        puloAudio.Stop();
    }

    public void temaStop() {
        temaAudio.Stop();
    }

    public void tiroStop() {
        tiroAudio.Stop();
    }

}