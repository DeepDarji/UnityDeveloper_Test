using UnityEngine;

public class GravityWallShift : MonoBehaviour
{
    public GameObject hologram;
    private Vector3 gravityDirection;
    private Vector3 hologramPosition;

    void Update()
    {
        ShowHologram();
        ShiftGravity();
    }

    void ShowHologram()
    {
        hologram.SetActive(false); // Hide hologram by default

        if (Input.GetKey(KeyCode.UpArrow))
        {
            hologramPosition = transform.position + transform.forward * 2f;
            gravityDirection = transform.forward;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            hologramPosition = transform.position - transform.forward * 2f;
            gravityDirection = -transform.forward;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            hologramPosition = transform.position - transform.right * 2f;
            gravityDirection = -transform.right;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hologramPosition = transform.position + transform.right * 2f;
            gravityDirection = transform.right;
        }
        else
        {
            return; // No arrow key pressed, do not show hologram
        }

        // Show hologram at the calculated position
        hologram.transform.position = hologramPosition;
        hologram.SetActive(true);
    }

    void ShiftGravity()
    {
        if (Input.GetKeyDown(KeyCode.Return) && hologram.activeSelf)
        {
            Physics.gravity = gravityDirection * 9.81f;

            // Rotate player to align with new gravity direction
            transform.rotation = Quaternion.FromToRotation(Vector3.up, -gravityDirection) * transform.rotation;

            // Deactivate hologram after gravity shift
            hologram.SetActive(false);
        }
    }
}
