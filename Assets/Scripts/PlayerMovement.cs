using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody playerRigidbody;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Get input axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Determine the movement direction relative to the player's current orientation
        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Apply the movement relative to the current gravity
        playerRigidbody.MovePosition(playerRigidbody.position + movement * speed * Time.deltaTime);
    }
}
