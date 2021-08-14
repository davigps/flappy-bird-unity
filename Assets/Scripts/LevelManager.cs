using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static LevelManager levelManager;
    
    private int currentPoints = 0;

    public Text pointsText;

    void Awake() {
        if (levelManager == null) {
            levelManager = this;
        } else if (levelManager != this) {
            Destroy(gameObject);
        }
    }

    public void UpdatePoints() {
        currentPoints++;
        pointsText.text = currentPoints.ToString();
    }
}
