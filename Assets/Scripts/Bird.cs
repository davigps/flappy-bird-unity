using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {
    public float speed = 4;
    public float force = 600;
    private Rigidbody2D body;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.right * speed;
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                ImpulseBird();
            }
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            ImpulseBird();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ImpulseBird() {
        body.AddForce(Vector2.up * force);
    }
}
