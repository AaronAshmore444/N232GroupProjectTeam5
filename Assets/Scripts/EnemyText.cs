using UnityEngine;
using TMPro;

public class EnemyText : MonoBehaviour
{
    public static EnemyText Instance; // Singleton for easy access
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
