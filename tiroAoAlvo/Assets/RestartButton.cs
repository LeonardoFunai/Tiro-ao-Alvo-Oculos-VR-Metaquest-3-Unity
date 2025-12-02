using UnityEngine;

public class RestartButton : MonoBehaviour
{
    // Crie uma refer�ncia para o Game Manager
    // Voc� vai arrastar o objeto _GameManager aqui no Inspector.
    public GameManager gameManager;

    // Esta fun��o � chamada quando outro collider (seu proj�til) colide com este objeto.
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido tem a Tag "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Opcional: Destruir a bala ap�s a colis�o
            Destroy(collision.gameObject);

            // Chama a fun��o de Reiniciar o Jogo no Game Manager
            if (gameManager != null)
            {
                gameManager.RestartGame(); // <-- CHAMA A FUN��O DE REINICIAR
            }
        }
    }
}