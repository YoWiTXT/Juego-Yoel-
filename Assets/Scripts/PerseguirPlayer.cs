using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float speed = 3f;
    public float minDistance = 1.5f; // Distancia mínima para evitar que se solape

    private void Awake()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (player == null)
            return;
        transform.LookAt(player.transform.position);
        Perseguir();



    }
    
    void Perseguir()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > minDistance) // Solo se mueve si está fuera del límite
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
    }
}
