using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtacck : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; //Variable que almacena el prefab
    [SerializeField]
    private Transform[] posRotBullet; // Variable que almacena posiciones de los Empty Objects
    [SerializeField]
    private float timeBetweenBullets;// Variable para ajustar el tiempo entre disparos
    private AudioSource shootAudio; // Variable para almacenar el componente AudioSource
    void Awake()
    {
        shootAudio = GetComponent<AudioSource>(); // Cargamos el componente
        InvokeRepeating("Attack", 1, timeBetweenBullets); // Llamamos al método y repetimos
    }

    private void Attack()

    {
        shootAudio.Play();
        for (int i = 0; i < posRotBullet.Length; i++)
        {
            Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);

        }

    }
}
