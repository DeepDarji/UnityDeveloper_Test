using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        // Keep the camera following the player
        transform.position = player.position + player.rotation * offset;

        // Rotate the camera to always look at the player
        transform.LookAt(player.position);
    }
}
