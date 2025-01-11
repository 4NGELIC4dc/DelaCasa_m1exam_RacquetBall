using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    private int hitCount = 0;
    private int highscore = 0;
    private bool gameStarted = false;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateHighscoreText();
        UpdateScoreText();
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))  
            {
                gameStarted = true;
                hitCount = 0; 
                UpdateScoreText();
            }
        }
    }

    public void IncreaseHitCount()
    {
        if (gameStarted)
        {
            hitCount++; 
            UpdateScoreText();
            Debug.Log("Hit Count Increased: " + hitCount);

            if (hitCount > highscore)
            {
                highscore = hitCount;
                PlayerPrefs.SetInt("Highscore", highscore);
                UpdateHighscoreText();
                Debug.Log("New Highscore: " + highscore);
            }
        }
    }

    public void ResetGame()
    {
        gameStarted = false;
        hitCount = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Hits: " + hitCount;
    }

    private void UpdateHighscoreText()
    {
        highscoreText.text = "Highscore: " + highscore;
    }
}
