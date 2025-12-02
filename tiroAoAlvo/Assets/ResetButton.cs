using UnityEngine;

public class ResetButton : MonoBehaviour
{
    // Crie uma refer�ncia p�blica ou serializada para o Game Manager
    // Voc� vai arrastar o objeto Game Manager para esta vari�vel no Inspector do Unity.
    public GameManager gameManager;

    // Esta fun��o � chamada quando outro collider (seu proj�til) colide com este objeto.
    private void OnCollisionEnter(Collision collision)
    {
        // Certifique-se de que o objeto colidido � o seu proj�til.
        // � bom usar Tags para isso (ex: "Bullet").
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Opcional: Destruir a bala ap�s a colis�o
            Destroy(collision.gameObject);

            // Chama a fun��o de reset no Game Manager
            if (gameManager != null)
            {
                gameManager.ResetTargets();
            }
        }
    }
}