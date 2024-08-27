using UnityEngine;

public class WallShift : MonoBehaviour
{
    public WallHologram wallHologramScript; // Reference to the WallHologram script
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable default gravity handling
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && wallHologramScript.hologram.activeSelf)
        {
            // Adjust gravity to match the wall's orientation
            Physics.gravity = -wallHologramScript.hologram.transform.forward * 9.81f;

            // Align the player to stand on the wall
            Quaternion targetRotation = Quaternion.LookRotation(-wallHologramScript.hologram.transform.forward, wallHologramScript.hologram.transform.up);
            transform.rotation = targetRotation;

            // Position the player correctly on the wall
            Vector3 offset = wallHologramScript.hologram.transform.up * 1.1f; // Adjust this value to ensure the player is on the surface
            rb.MovePosition(wallHologramScript.hologram.transform.position + offset);

            // Reset velocity to avoid continuous movement
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Disable the hologram
            wallHologramScript.hologram.SetActive(false);
        }
    }
}
