using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject standingFanObject;
    public Rigidbody2D playerRigidbody2D;
    public float growSpeed = 5f;
    public float horizontalSpeed = 8f;
    public bool isHolding = false;
    //public Rigidbody2D standingFanRigidbody2D;
    // Start is called before the first frame update
    public string targetTag = "teleporter";
    public string sceneName = "MenuNiveles";

    private Animator animator;
    void Start()
    {
        playerRigidbody2D = playerObject.GetComponent<Rigidbody2D>();
        //standingFanRigidbody2D = standingFanObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if (playerObject.transform.localPosition.y - standingFanObject.transform.localPosition.y <= 5f){
            //playerRigidbody2D.mass = 0f;
            //playerRigidbody2D.gravityScale = 0f;
            //playerRigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        } else {
            //playerRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }*/

        if (playerRigidbody2D != null)
        {
            playerRigidbody2D.velocity = new Vector2(horizontalSpeed, playerRigidbody2D.velocity.y);
        }

        Vector2 vector = new Vector2(0, 0.28f);

        if( isHolding && playerRigidbody2D != null && playerObject.transform.position.y - standingFanObject.transform.position.y <= 40f)
        {
            playerRigidbody2D.velocity = new Vector2(horizontalSpeed, 0f);;
            playerRigidbody2D.AddForce(vector * growSpeed, ForceMode2D.Impulse);
            //Debug.Log("waaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaats");
        }
    }

    public void PlayerController()
    {
        
    }

    public void OnButtonDown() {
        isHolding = true;
    }

    public void OnButtonUp() {
        isHolding = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(targetTag)){
            SceneManager.LoadScene(sceneName);
            Debug.Log(collision.gameObject.tag);
        }else {
            animator.SetTrigger("PlayDeath");
            Invoke("RestartLevel", 0.2f);
        }
        // Reinicia el nivel después de 2 segundos
        //
    }

    // Método para reiniciar el nivel
    public void RestartLevel()
    {
        Destroy(playerObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
