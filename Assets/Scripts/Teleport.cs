using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suelo_Radioactivo"))
        {
            // Teleport the object to the destination
            transform.position = destination.position;
        }
    }
}
