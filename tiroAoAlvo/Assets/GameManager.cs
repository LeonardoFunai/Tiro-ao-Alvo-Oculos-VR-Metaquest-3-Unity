using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Lista de Alvos para Resetar")]
    // Lista de todos os alvos que precisam ser resetados
    public List<GameObject> allTargets;

    // Posições e Rotações iniciais para onde os alvos devem retornar
    private List<Vector3> initialPositions = new List<Vector3>();
    private List<Quaternion> initialRotations = new List<Quaternion>();



    void Start()
    {
        // **IMPORTANTE:** Armazene as posições e rotações iniciais no Start
        foreach (GameObject target in allTargets)
        {
            // Verifica se o alvo é nulo antes de tentar acessar o transform
            if (target != null)
            {
                initialPositions.Add(target.transform.position);
                initialRotations.Add(target.transform.rotation);
            }
        }
    }

    public void RestartGame()
    {
        Debug.Log("Reiniciando o Jogo!");

        // 1. Pega o nome da cena que está carregada no momento
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 2. Recarrega a cena pelo nome. Isso reseta TUDO!
        SceneManager.LoadScene(currentSceneName);
    }

    // Função que será chamada pelo botão para resetar
    public void ResetTargets()
    {
        Debug.Log("Resetando Alvos! Total: " + allTargets.Count);

        for (int i = 0; i < allTargets.Count; i++)
        {
            GameObject target = allTargets[i];

            // Garante que o alvo não foi destruído
            if (target == null) continue;

            // Garante que a posição/rotação inicial existe na lista
            if (i >= initialPositions.Count) continue;


            // 1. Resetar Posição: Move o alvo para a posição inicial
            target.transform.position = initialPositions[i];

            // 2. Resetar Rotação: Usa a rotação armazenada
            target.transform.rotation = initialRotations[i];

            // 3. Reativar Componentes (ex: se o alvo é desativado)
            target.SetActive(true);

            // 4. Resetar Rigidbody (limpar a física)
            Rigidbody rb = target.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Limpa a velocidade e a velocidade de rotação
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Garante que a física está ativa para futuras colisões
                rb.isKinematic = false;
            }
        }
    }
}