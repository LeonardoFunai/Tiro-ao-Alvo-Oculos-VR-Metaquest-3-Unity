using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Configurações do Projétil")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 40f;
    public float bulletLifetime = 5f;

    [Header("Configurações do Rifle")]
    // Tiros por segundo (ex: 5.0f = 5 tiros por segundo)
    public float fireRate = 5.0f;

    [Header("Configurações de Áudio")]
    public AudioClip clip;
    private AudioSource source;

    // Controle de estado e tempo
    private bool isFiring = false;
    private float nextFireTime = 0f; // Quando o próximo tiro pode ser disparado

    // Inicializa o componente AudioSource
    private void Start()
    {
        source = GetComponent<AudioSource>();
        // Garante que o Rigidbody do rifle não interfira na mira, se houver
        // if (GetComponent<Rigidbody>() != null) GetComponent<Rigidbody>().isKinematic = true; 
    }

    // O loop Update() é chamado a cada frame
    private void Update()
    {
        // 1. Checa se o gatilho está pressionado (isFiring == true)
        // 2. Checa se o tempo atual (Time.time) é maior ou igual ao tempo que podemos atirar novamente (nextFireTime)
        if (isFiring && Time.time >= nextFireTime)
        {
            // Se ambas as condições forem verdadeiras, dispara o tiro
            Shoot();
        }
    }

    // MÉTODOS PÚBLICOS CHAMADOS PELO INPUT (Gatilho)

    // Chamado quando o gatilho é Pressionado
    public void StartFiring()
    {
        isFiring = true;
        // Opcional: Chama Shoot() imediatamente para o primeiro tiro ser instantâneo
        // Se você não fizer isso, ele só atira no próximo frame do Update()
        if (Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    // Chamado quando o gatilho é Solto
    public void StopFiring()
    {
        isFiring = false;
    }


    // LÓGICA DE DISPARO (Apenas a parte que cria a bala)
    private void Shoot()
    {
        // Define o tempo do próximo tiro
        // (1f / fireRate) é o intervalo em segundos entre os tiros.
        nextFireTime = Time.time + 1f / fireRate;

        // 1. Cria a bala no ponto de disparo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 2. Tenta pegar o Rigidbody da bala
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // 3. Toca o som de disparo (se houver)
        if (source != null && clip != null)
        {
            source.PlayOneShot(clip);
        }

        // 4. Aplica velocidade
        if (rb != null)
        {
            // A velocidade linear é a propriedade correta no Rigidbody
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        // 5. Destrói a bala após um tempo definido
        Destroy(bullet, bulletLifetime);
    }
}