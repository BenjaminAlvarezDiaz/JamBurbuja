using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class teleporter : MonoBehaviour
{
    public string targetTag = "player";
    public string sceneName = "MenuNiveles";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto tiene el tag especificado
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Carga la escena especificada
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto tiene el tag especificado
        if (other.gameObject.CompareTag(targetTag))
        {
            // Carga la escena especificada
            SceneManager.LoadScene(sceneName);
        }
    }
}
