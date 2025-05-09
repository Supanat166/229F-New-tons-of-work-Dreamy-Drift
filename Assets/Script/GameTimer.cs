using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public GameObject timerCanvas;  

    private bool isGameOver = false;

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (timerCanvas != null)
        {
            timerCanvas.SetActive(true);  
        }
    }

    private void Update()
    {
        if (isGameOver) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            GameOver();
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void GameOver()
    {
        isGameOver = true;
        timeRemaining = 0;
        UpdateTimerDisplay();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (timerCanvas != null)
        {
            timerCanvas.SetActive(false);  // ซ่อน TimerCanvas เมื่อเกมจบ
        }

        Time.timeScale = 0;
        Debug.Log("Game Over! Time is up.");
    }
}
