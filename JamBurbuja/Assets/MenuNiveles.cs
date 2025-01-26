using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public void PrimerNivel()
    {
        SceneManager.LoadScene("COCINA");
    }
    
    public void SegundoNivel()
    {
        SceneManager.LoadScene("BANO");
    }
    
}
