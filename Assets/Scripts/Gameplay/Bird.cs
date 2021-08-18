using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float speed;
    public float force;
    private Rigidbody2D body;
    private float rotationZ;
    public float rotationSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.right * speed;
    }

    void Update()
    {
        GetPlayerInput();
        RotateBird();

        if (transform.position.y > 13)
        {
            RestartGame();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        LevelManager.levelManager.UpdateHighscore();
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void GetPlayerInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ImpulseBird();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ImpulseBird();
        }
    }

    private void ImpulseBird()
    {
        body.AddForce(Vector2.up * force);
    }

    private void RotateBird()
    {
        if (body.velocity.y > 0)
        {
            rotationZ += Time.deltaTime * rotationSpeed;
        }
        else
        {
            rotationZ -= Time.deltaTime * (rotationSpeed * 0.8f);
        }

        if (Mathf.Abs(rotationZ) > 30)
        {
            rotationZ = rotationZ > 0 ? 30 : -30;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
