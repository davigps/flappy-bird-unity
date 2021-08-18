using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;


    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }

    void Update()
    {
        float targetEnd = target.position.x - 48;
        float targetOrigin = target.position.x + 48;

        if (transform.position.x < targetEnd)
        {
            transform.position = new Vector3(targetOrigin, transform.position.y, transform.position.z);
        }
    }
}
