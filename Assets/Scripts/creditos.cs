using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{
    // Fun��o para o bot�o "Play"
    public void credito()
    {
        // Carrega a cena chamada "In�cio"
        SceneManager.LoadScene("creditos e comandos");
    }

}