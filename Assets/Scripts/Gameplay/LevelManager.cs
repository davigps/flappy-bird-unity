using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager levelManager;

    private int currentPoints = 0;
    private int highscore;

    public Text pointsText;

    public AudioSource pointAudio;
    public AudioSource specialAudio;

    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
            highscore = PlayerPrefs.GetInt("Highscore");

            float appVolume = PlayerPrefs.GetFloat("Volume");
            specialAudio.volume = appVolume;
            pointAudio.volume = appVolume;
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

    public void UpdateHighscore()
    {
        if (currentPoints > highscore)
        {
            highscore = currentPoints;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
    }
}
