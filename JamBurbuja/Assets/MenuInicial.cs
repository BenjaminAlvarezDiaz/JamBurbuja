using UnityEngine;

public class MenuInicial : MonoBehaviour
{

    public void OnExitButtonClick()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
