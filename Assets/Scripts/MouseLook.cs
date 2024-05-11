using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float velocidadRotacion = 5.0f; // Velocidad de rotaci�n de la c�mara
    public bool invertirEjeY = false; // Variable para invertir el eje Y

    void Start()
    {
        // Hacer que el cursor del rat�n sea invisible
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener la posici�n del rat�n en la pantalla
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calcular la rotaci�n en los ejes X y Y
        float rotacionX = transform.localEulerAngles.y + mouseX * velocidadRotacion;

        float rotacionY = transform.localEulerAngles.x - mouseY * velocidadRotacion;
        if (invertirEjeY)
        {
            rotacionY = transform.localEulerAngles.x + mouseY * velocidadRotacion;
        }

        // Limitar la rotaci�n vertical entre -90 y 90 grados para evitar volteos
        rotacionY = Mathf.Clamp(rotacionY, -100f, 1000000f);
   
        // Rotar la c�mara verticalmente y horizontalmente
        transform.localEulerAngles = new Vector3(rotacionY, rotacionX, 0);
    }
}
