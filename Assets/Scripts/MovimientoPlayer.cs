using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con la interfaz gr�fica

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    // Variables de salud

    [SerializeField]
    private float maxHealth = 100;
    private float currentHealth = 100;
    [SerializeField]
    private float damageBullet = 5;


    // Variables de Bala
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;
    [SerializeField]
    private AudioSource shootAudio;


    // Barra de vida
    [SerializeField]
    private Image lifeBar;

    //GAME OVER
    [SerializeField]
    private GameObject gameOver;
    
    void Awake()
    {
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
        shootAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
         
        // Movimiento con el teclado
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Disparar();
    }

    // Detectar colisi�n con proyectiles del enemigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            currentHealth -= damageBullet; // Da�o causado
            lifeBar.fillAmount = currentHealth / maxHealth; // C�lculo de la relaci�n de salud
            Destroy(other.gameObject); // Destruimos el proyectil
            if (currentHealth <= 0)
            { // Comprobamos si hemos muerto
                Death();
            }
        }
    }
    private void Death()
    {
        Camera.main.transform.SetParent(null); // Antes de destruir el objeto deshacer la jerarqu�a
        Destroy(gameObject); // Camera.main es la c�mara con el tag "MainCamera"
        gameOver.SetActive(true);
    }
    private void Disparar()


    {
        if (Input.GetMouseButtonDown(0))
        {

            for (int i = 0; i < posRotBullet.Length; i++)
            {
                Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
            }
            shootAudio.Play();
        }
    }
}
