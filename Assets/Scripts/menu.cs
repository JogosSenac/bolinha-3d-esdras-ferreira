using UnityEngine;
using UnityEngine.SceneManagement; // Biblioteca para controle de cenas

public class MenuController : MonoBehaviour
{
    // Função para o botão "Play"
    public void PlayGame()
    {
        // Carrega a cena chamada "Início"
        SceneManager.LoadScene("Inicio");
    }
}