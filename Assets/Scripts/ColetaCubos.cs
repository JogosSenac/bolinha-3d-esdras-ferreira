using UnityEngine;
using UnityEngine.SceneManagement;

public class ColetaCubos : MonoBehaviour
{
    
    private GameObject[] CuboBrilhante;

    void Start()
    {
        
        CuboBrilhante = GameObject.FindGameObjectsWithTag("CuboBrilhante");
    }

    void Update()
    {
        
        if (TodosCubosColetados())
        {
            
            SceneManager.LoadScene("Fase2");
        }
    }

    
    bool TodosCubosColetados()
    {
        
        foreach (GameObject cubo in CuboBrilhante)
        {
            if (cubo != null)
            {
                return false; 
            }
        }
        return true;
    }

    
    public void ColetarCubo(GameObject cubo)
    {
       
        Destroy(cubo);
    }
}