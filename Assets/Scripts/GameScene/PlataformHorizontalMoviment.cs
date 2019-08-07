using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlataformHorizontalMoviment : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform minPosition;
    [SerializeField]
    private Transform maxPosition;

    private Rigidbody2D rb;

    private float maxX;
    private float minX;
    private bool isPaused;

    void Awake() {
        sortPositions();

        maxX = maxPosition.position.x;
        minX = minPosition.position.x;

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = (Random.Range(0, 100) < 50) ? speed * Vector2.right : speed * Vector2.left;
    }
    
    void Update() {
        if (!isPaused) {
            if (rb.velocity.x > 0) {
                //transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x >= maxX) {
                    rb.velocity = Vector2.left * speed;
                }
            } else {
                //transform.position -= Vector3.right * speed * Time.deltaTime;

                if (transform.position.x <= minX) {
                    rb.velocity = Vector2.right * speed;
                }
            }
        }
    }

    private void sortPositions() {
        if (maxPosition.position.x < minPosition.position.x) {
            Transform auxPosition = maxPosition;
            maxPosition = minPosition;
            minPosition = auxPosition;
        }
    }

    public void setPause(bool isPaused) {
        this.isPaused = isPaused;
    }

}
