using UnityEngine;
using UnityEngine.UI; // For UI elements

public class CubeCollection : MonoBehaviour
{
    public Text scoreText;   // UI Text to display the score
    private int score = 0;   // Score variable

    void Start()
    {
        // Initialize the score display
        UpdateScoreText();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Collectible" tag
        if (collision.gameObject.CompareTag("Collectible"))
        {
            // Destroy the collectible cube
            Destroy(collision.gameObject);

            // Increase the score
            score += 1;

            // Update the score display
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        // Update the score UI text
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
