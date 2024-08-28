using UnityEngine;

public class HologramController : MonoBehaviour
{
    public GameObject hologram;
    public LayerMask wallLayer;
    public Rigidbody playerRigidbody;
    public Transform player;

    private Vector3 targetUp;

    void Start()
    {
        hologram.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (IsWall(collision.gameObject))
        {
            EnableHologram(collision.contacts[0]);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (IsWall(collision.gameObject))
        {
            DisableHologram();
        }
    }

    void EnableHologram(ContactPoint contact)
    {
        hologram.SetActive(true);
        hologram.transform.position = contact.point;

        // Set the up direction of the hologram to be the same as the wall's normal
        hologram.transform.rotation = Quaternion.FromToRotation(hologram.transform.up, contact.normal) * hologram.transform.rotation;

        // Store the direction to use for shifting the player later
        targetUp = contact.normal;
    }

    void DisableHologram()
    {
        hologram.SetActive(false);
    }

    bool IsWall(GameObject obj)
    {
        return obj.layer == LayerMask.NameToLayer("Wall");
    }

    void Update()
    {
        if (hologram.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            ShiftPlayerToWall();
        }
    }



    void ShiftPlayerToWall()
    {
        // Rotate the player to align their up direction with the wall's normal
        Quaternion rotation = Quaternion.FromToRotation(player.up, targetUp) * player.rotation;
        player.rotation = rotation;

        // Adjust gravity so that the wall becomes the new "ground"
        Physics.gravity = -targetUp * Physics.gravity.magnitude;

        // Instantly move the player to the hologram's position and adjust their orientation
        player.position = hologram.transform.position;

        // Reset player velocity to prevent weird physics effects
        playerRigidbody.velocity = Vector3.zero;

        // Update the camera focus to the player's head
        Camera.main.GetComponent<CameraFollow>().UpdateOffset(Camera.main.GetComponent<CameraFollow>().offset);
    }


    /*    void ShiftPlayerToWall()
        {
            // Rotate the player to align their up direction with the wall's normal
            Quaternion rotation = Quaternion.FromToRotation(player.up, targetUp) * player.rotation;
            player.rotation = rotation;

            // Adjust gravity so that the wall becomes the new "ground"
            Physics.gravity = -targetUp * Physics.gravity.magnitude;

            // Instantly move the player to the hologram's position and adjust their orientation
            player.position = hologram.transform.position;

            // Reset player velocity to prevent weird physics effects
            playerRigidbody.velocity = Vector3.zero;
        }*/
}
