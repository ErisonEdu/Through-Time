using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded;
    private BoxCollider2D collider;
    private Animator animator;
    private bool isFacingLeft = false;
    private int minLife = 0;
    private int maxLife = 15;
    private int life;

    private int minBomb = 0;
    private int maxBomb = 3;
    private int bombs;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce = 100f, maxspeed = 12f;

    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private Transform shotSpawn;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private GameController gameController;

    private float nextFire = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb          = GetComponent  <Rigidbody2D>();
        collider    = GetComponent  <BoxCollider2D>();
        animator    = GetComponent  <Animator>();
        life        = maxLife;
        bombs       = minBomb;

        extraLife(maxLife);
        loseBomb(maxBomb);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveJump = Input.GetAxis("Jump");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb.AddForce(movement * speed);

        if (rb.velocity.magnitude > maxspeed)
        {
            Vector2 aux = rb.velocity.normalized * maxspeed;
            aux.y = rb.velocity.y;
            rb.velocity = aux;
            //rb.velocity = rb.velocity.normalized * maxspeed;
        }

        if (moveHorizontal < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            
            MirrorSprite(-1, 1);
        }
        else if (moveHorizontal > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            
            MirrorSprite(-1, 1);
        }

        Vector2 jump = new Vector2(0, moveJump);

        if (grounded && moveJump > 0)
        {
            rb.AddForce(jump * jumpForce);
            animator.SetTrigger("jumping");  
            //source.Play();
        }

        if (rb.velocity.y > 0f && !grounded)
        {
            animator.SetBool("falling", false);
        }

        //Ativa a animação CAINDO
        if (rb.velocity.y < 0f && !grounded)
        {
            animator.SetBool("falling", true);
        }
        
        if (Mathf.Abs(rb.velocity.x) > 0.25f)
        {
            animator.SetBool("running", true);
        }
        else {
            animator.SetBool("running", false);
        }

        if (Input.GetAxis("Fire1") == 1f && Time.time > nextFire)
        {
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            clone.GetComponent<Bullet>().SetPlayer(this);
            nextFire = Time.time + fireRate;
            animator.SetTrigger("shooting");
        }

        if (Input.GetAxis("Fire2") == 1f && Time.time > nextFire /*&& bombs > 0*/)
        {
            GameObject clone = Instantiate(bomb, shotSpawn.position, shotSpawn.rotation) as GameObject;
            clone.GetComponent<Bomb>().SetPlayer(this);
            nextFire = Time.time + fireRate;
            animator.SetTrigger("shooting");
        }

        animator.SetBool("inGround", grounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            grounded = true;
        }

        if (collision.gameObject.tag.Equals("enemy"))
        {
            loseLife(1);
        }

        if (collision.gameObject.tag.Equals("hole"))
        {
            loseLife(maxLife);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            grounded = false;
        }
    }

    public void loseLife(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            life = 0;
        }

        rb.AddForce(new Vector2(-250, 500));

        gameController.setLife(life);

        // Imortalidade durante alguns segundos.
    }

    public void extraLife(int extraLife)
    {
        life += extraLife;

        if (life >= maxLife)
        {
            life = maxLife;
        }

        gameController.setLife(life);
    }

    public void loseBomb(int bombToLose)
    {
        bombs -= bombToLose;

        if (bombs <= 0)
        {
            bombs = 0;
        }

        gameController.setBomb(bombs);
    }

    public void extraBomb(int bombToWin)
    {
        bombs += bombToWin;

        if (bombs >= maxBomb)
        {
            bombs = maxBomb;
        }

        gameController.setBomb(bombs);
    }

    private void MirrorSprite(float x, float y)
    {
        Vector3 localScale = transform.localScale; // Usar sempre o local ao inves da variavel absoluta (scale)

        localScale.x *= x;
        localScale.y *= y;

        transform.localScale = localScale;
    }

    public void AddScore(int scoreToAdd) {
        gameController.addPoints(scoreToAdd);
    }

    public bool getFacingLeft() {
        return isFacingLeft;
    }

}
