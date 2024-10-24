using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{
    // Função para o botão "Play"
    public void credito()
    {
        // Carrega a cena chamada "Início"
        SceneManager.LoadScene("creditos e comandos");
    }

}