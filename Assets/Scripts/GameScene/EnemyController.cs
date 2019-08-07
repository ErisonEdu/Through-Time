using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int maxLife;
    private int life;

    [SerializeField]
    private int damage;

    [SerializeField]
    private int score;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Player player;
    private Rigidbody2D rb;
    private bool isFacingLeft = false;
    private bool isGrounded = false;
    private float timeToWaitWall = 0.5f;
    private float actualTime = 0f;

    private void Awake()
    {
        maxLife = 3;
        life = maxLife;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D> ();

        rb.velocity = Vector2.left * speed;
    }

    void Update()
    {
        /*
        if(Vector2.Distance(transform.position, player.transform.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        */

        if (rb.velocity.x < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            
            MirrorSprite(-1, 1);
        }
        else if (rb.velocity.x > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            
            MirrorSprite(-1, 1);
        }

        Debug.Log("Velocidade X absoluta: " + Mathf.Abs(rb.velocity.x));
        Debug.Log("Speed: " + speed);
        Debug.Log("Grounded: " + isGrounded);

        if (Mathf.Abs(rb.velocity.x) < speed && isGrounded) {
            Debug.Log("Teste");
            rb.velocity = isFacingLeft ? Vector2.left * speed : Vector2.right * speed;
        }

        if (actualTime > 0) {
            actualTime -= Time.deltaTime;
        }
    }

    private void MirrorSprite(float x, float y)
    {
        Vector3 localScale = transform.localScale; // Usar sempre o local ao inves da variavel absoluta (scale)

        localScale.x *= x;
        localScale.y *= y;

        transform.localScale = localScale;
    }

    public void receberDano(int dano) {
        life -= dano;
        if (life <= 0) {
            getPoints();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            player.loseLife(damage);
        }

        if (collision.gameObject.tag.Equals("hole"))
        {
            getPoints();
        }

        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("wallLimit"))
        {
            if (actualTime <= 0) {
                rb.velocity = isFacingLeft ? Vector2.right * speed : Vector2.left * speed;
                actualTime = timeToWaitWall;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;
        }
    }

    private void getPoints() {
        player.AddScore(score);

        Destroy(this.gameObject);
    }

}