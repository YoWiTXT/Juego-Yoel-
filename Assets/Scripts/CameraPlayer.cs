using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Asigna el jugador en el inspector
    public Vector3 offset;    // Distancia entre la c�mara y el jugador

    void Start()
    {
        // Asegura  que la c�mara tiene un desplazamiento inicial
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void Update()
    {
        if (player == null)
            return;
        // Actualiza la posici�n de la c�mara para que siga al jugador
        transform.position = player.position + offset;
    }
}
