using UnityEngine;

public class Teleport3 : MonoBehaviour
{
    public Transform destination;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suelo_Radioactivo3"))
        {
            // Teleport the object to the destination
            transform.position = destination.position;
        }
    }
}
