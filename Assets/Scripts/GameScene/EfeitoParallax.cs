using UnityEngine;
using UnityEngine.UI;

public class EfeitoParallax : MonoBehaviour
{
    [SerializeField] private Transform[] imagens;
    [SerializeField] private float[] velocidades;

    private float startX;

    private void Awake()
    {
        startX = transform.position.x;
    }

    private void Update()
    {
        MoveFundo();
    }

    public void MoveFundo()
    {
        float distance = transform.position.x - startX;
        for (int i = 0; i < imagens.Length; i++) {
            imagens[i].position -= new Vector3(distance * velocidades[i], imagens[i].position.y, imagens[i].position.z);
        }
    }
}