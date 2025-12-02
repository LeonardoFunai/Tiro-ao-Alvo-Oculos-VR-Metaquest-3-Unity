using UnityEngine;

public class Pistol : MonoBehaviour
{
[Header("Bullet Settings")]
 // Vari�veis p�blicas no Editor
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 5f; // seconds before bullet is destroyed

     public AudioClip clip;
        private AudioSource source;

     // Inicializa o componente AudioSource
     private void Start()
        {
            source = GetComponent<AudioSource>();
        }

     // M�todo para disparar a bala
     public void FireBullet()
        {

            // 1. Cria a bala no ponto de disparo
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

     // 2. Tenta pegar o Rigidbody da bala
     Rigidbody rb = bullet.GetComponent<Rigidbody>();

     // 3. Toca o som de disparo
     source.PlayOneShot(clip);

     // 4. Aplica velocidade se o Rigidbody existir
    if (rb != null)
            {
                rb.linearVelocity = firePoint.forward * bulletSpeed;
            }

    // 5. Destr�i a bala ap�s um tempo definido
     Destroy(bullet, bulletLifetime);
        }
}
