using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;
    public float timeLimit = 120f; // 2 minutes

    void Update()
    {
        timeLimit -= Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.Floor(timeLimit).ToString();

        if (timeLimit <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Display Game Over UI or restart the level
        Debug.Log("Game Over!");
    }
}
