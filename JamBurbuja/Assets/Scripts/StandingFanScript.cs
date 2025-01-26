using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StandingFanScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //public GameObject targetObject; // El objeto que crecerá
    //public Rigidbody2D targetRigidbody2D;
    //public float growSpeed = 50f; // Velocidad de crecimiento

    //private bool isPressed = false;

    public Rigidbody2D playerRigidbody2D;
    public float horizontalSpeed = 2f;
    void Start()
    {
        //targetRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*if (isPressed != false)
        {
            Debug.Log("Nyaaaaaaaaaaaaa");
            targetRigidbody2D.velocity = Vector2.zero;
            targetRigidbody2D.AddForce(Vector2.up * growSpeed, ForceMode2D.Impulse);
            // Aumenta la altura del objeto mientras el botón está presionado
            //Vector3 position = targetObject.transform.localPosition;
            //position.y += growSpeed * 0.01f;
            //targetObject.transform.position = position;
        }*/

        if (playerRigidbody2D != null)
        {
            playerRigidbody2D.velocity = new Vector2(horizontalSpeed, playerRigidbody2D.velocity.y);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //isPressed = true; // Cuando se presiona el botón
        /*targetRigidbody2D.gravityScale = 0;
        targetRigidbody2D.mass = 0;*/
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //isPressed = false; // Cuando se suelta el botón
        /*targetRigidbody2D.gravityScale = 0.2f;
        targetRigidbody2D.mass = 0.2f;*/
    }
}
