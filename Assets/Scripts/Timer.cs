// File name: Timer.cs
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timeLimit = 120f;
    private float timeRemaining;
    private bool timerIsRunning = false;

    void Start()
    {
        timeRemaining = timeLimit;
        timerIsRunning = true;
        UpdateTimerText();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                OnTimerEnd();
            }
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60F);
            int seconds = Mathf.FloorToInt(timeRemaining % 60F);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void OnTimerEnd()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over!");
    }
}
