using UnityEngine;

public class Obstacle : MonoBehaviour {
    public Transform upLog;
    public Transform downLog;
    public bool isDownObstacle = false;
    private bool alreadyCreated = false;
    private bool gotPoint = false;
    private GameObject bird;

    void Start() {
        bird = GameObject.Find("bird_0");
    }

    void Update() {
        float birdX = bird.transform.position.x;

        if (isDownObstacle) {
            if (GetComponent<Renderer>().isVisible && !alreadyCreated) {
                CreateNextObstacles();
                alreadyCreated = true;
            }

            if (!gotPoint && transform.position.x < birdX) {
                LevelManager.levelManager.UpdatePoints();
                gotPoint = true;
            }
        }

        if (transform.position.x < birdX - 6) {
            Destroy(gameObject);
        }
    }

    void CreateNextObstacles() {
        float nextX = transform.position.x + Random.Range(6, 10);
        float targetY = Random.Range(11f, -2.5f);
        float deltaY = Random.Range(10f, 11f);

        Vector3 upLogPosition = new Vector3(nextX, targetY + deltaY, transform.position.z);
        Vector3 downLogPosition = new Vector3(nextX, targetY - deltaY, transform.position.z);

        Instantiate(upLog, upLogPosition, Quaternion.identity);
        Instantiate(downLog, downLogPosition, Quaternion.identity);
    }
}
