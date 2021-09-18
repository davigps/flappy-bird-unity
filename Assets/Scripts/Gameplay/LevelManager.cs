using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager levelManager;

    private int currentPoints = 0;
    private int highscore;

    public Text pointsText;

    public AudioSource pointAudio;
    public AudioSource specialAudio;
    public GameObject endMenu;

    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
            highscore = PlayerPrefs.GetInt("Highscore");

            GetAudioPreferences();
        }
        else if (levelManager != this)
        {
            Destroy(gameObject);
        }
    }

    private void GetAudioPreferences()
    {
        float appVolume = PlayerPrefs.GetFloat("Volume");
        appVolume = appVolume == 0f ? 0.5f : appVolume;

        specialAudio.volume = appVolume;
        pointAudio.volume = appVolume;
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

    public void OpenEndMenu()
    {
        UpdateHighscore();
        endMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
