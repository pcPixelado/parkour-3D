using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    public Transform destination;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suelo_Radioactivo2"))
        {
            // Teleport the object to the destination
            transform.position = destination.position;
        }
    }
}
