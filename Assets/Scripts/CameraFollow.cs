using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // The player to follow
    public Transform playerHead;      // The player's head or a specific point on the player to focus on
    public float smoothSpeed = 0.125f; // Smoothing speed for camera movement
    public float rotationSpeed = 5f;   // Speed at which the camera rotates to follow player

    public Vector3 offset;

    void Start()
    {
        // Set the initial camera offset
        offset = transform.position - playerHead.position;
    }

    void LateUpdate()
    {
        // Calculate desired camera position
        Vector3 desiredPosition = playerHead.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Smoothly rotate the camera to follow the player's orientation
        Quaternion desiredRotation = Quaternion.LookRotation(playerHead.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }

    public void UpdateOffset(Vector3 newOffset)
    {
        // Update the camera offset if needed
        offset = newOffset;
    }
}
