using UnityEngine;

public class WallHologram : MonoBehaviour
{
    public GameObject hologram; // Drag your hologram object here in the Inspector
    private Vector3 wallNormal;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallNormal = collision.contacts[0].normal;
            Vector3 hologramPosition = collision.contacts[0].point + wallNormal * 0.1f;

            hologram.transform.position = hologramPosition;
            hologram.transform.rotation = Quaternion.LookRotation(wallNormal);
            hologram.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            hologram.SetActive(false);
        }
    }
}
