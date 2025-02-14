using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Asigna el jugador en el inspector
    public Vector3 offset;    // Distancia entre la cámara y el jugador

    void Start()
    {
        // Asegura  que la cámara tiene un desplazamiento inicial
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void Update()
    {
        if (player == null)
            return;
        // Actualiza la posición de la cámara para que siga al jugador
        transform.position = player.position + offset;
    }
}
