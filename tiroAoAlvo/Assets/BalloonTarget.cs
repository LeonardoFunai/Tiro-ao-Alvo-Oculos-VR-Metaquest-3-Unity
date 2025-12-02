using UnityEngine;

public class BalloonTarget : MonoBehaviour
{
    // Removemos todas as vari�veis de �udio (popSoundClip e audioSource)

    private void Start()
    {
        // Removemos toda a l�gica de inicializa��o do AudioSource
    }

    // Chamado quando a bala colide com o bal�o (certifique-se que o bal�o tem um Collider)
    private void OnCollisionEnter(Collision collision)
    {
        // 1. Verifica se o objeto colidido tem a Tag "Bullet"
        // (Certifique-se que seu proj�til tem essa Tag!)
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 2. Garante que a bala seja destru�da para evitar m�ltiplas colis�es
            Destroy(collision.gameObject);

            // 3. Executa a L�gica de Estouro
            PopBalloon();
        }
    }

    private void PopBalloon()
    {
        // 1. Removemos a l�gica de tocar o som do estouro
        /*
        if (popSoundClip != null)
        {
             audioSource.PlayOneShot(popSoundClip);
        }
        */

        // 2. Faz o bal�o sumir
        // Usamos SetActive(false) para desativar o objeto. 
        // Isso permite que o GameManager o reative no reset.
        gameObject.SetActive(false);

        // Dica: Se precisar de feedback visual (ex: fuma�a), voc� pode instanciar uma 
        // part�cula aqui e destru�-la ap�s um tempo curto.
    }
}