using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    public GameObject startButton;
    private bool gameStarted = false;

    void Start()
    {
        // Show the button and stop the game
        startButton.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void StartGame()
    {
        // Hide the button and start the game
        startButton.SetActive(false);
        Time.timeScale = 1; // Resume the game
        gameStarted = true;
    }
}
