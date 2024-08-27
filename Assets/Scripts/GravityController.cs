using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravityStrength = 9.81f;
    private Vector3 gravityDirection;

    void Update()
    {
        ChangeGravity();
    }

    void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gravityDirection = Vector3.forward; // Forward
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gravityDirection = Vector3.back; // Backward
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gravityDirection = Vector3.left; // Left
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gravityDirection = Vector3.right; // Right
        }

        if (Input.GetKeyDown(KeyCode.Return)) // Enter key to apply gravity
        {
            Physics.gravity = gravityDirection * gravityStrength;
        }
    }
}
