using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPlayer : MonoBehaviour

{
    private int speed = 100; // Variable para ajustar la velocidad
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
