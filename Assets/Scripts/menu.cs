using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Fun��o para o bot�o "Play"
    public void PlayGame()
    {
        // Carrega a cena chamada "In�cio"
        SceneManager.LoadScene("Inicio");
    }

}