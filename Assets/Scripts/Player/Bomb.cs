using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private int damage;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        if (!player.getFacingLeft())
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.one * speed * new Vector2(1, 2.5f));
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * speed * new Vector2(1, 2.5f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.receberDano(damage);

            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag.Equals("ground"))
        {


            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Teste1");
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
