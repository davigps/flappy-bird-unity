using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager levelManager;

    private int currentPoints = 0;

    public Text pointsText;

    public AudioSource pointAudio;
    public AudioSource specialAudio;

    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
        else if (levelManager != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdatePoints()
    {
        currentPoints++;
        pointsText.text = currentPoints.ToString();

        if (currentPoints % 10 == 0)
        {
            specialAudio.Play();
        }
        else
        {
            pointAudio.Play();
        }
    }
}
