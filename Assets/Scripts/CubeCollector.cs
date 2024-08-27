using UnityEngine;
using UnityEngine.UI;

public class CubeCollector : MonoBehaviour
{
    public Text cubeCounterText; // Reference to the UI Text element
    private int cubesCollected = 0;

    void Start()
    {
        UpdateCubeCounter(); // Initialize the counter text
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            cubesCollected++;
            Destroy(other.gameObject);
            UpdateCubeCounter(); // Update the counter text after collecting a cube
        }
    }

    void UpdateCubeCounter()
    {
        cubeCounterText.text = "Cubes Collected: " + cubesCollected;
    }
}
