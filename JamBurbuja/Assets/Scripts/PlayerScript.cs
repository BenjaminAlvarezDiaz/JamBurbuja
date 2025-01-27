using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class PlayerScript : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject standingFanObject;
    public Rigidbody2D playerRigidbody2D;
    public float growSpeed = 5f;
    public float horizontalSpeed = 8f;
    public bool isHolding = false;
    
    private AudioSource audioSource;
    private float maxPitch = 20f;
    private float pitchIncreaseRate = 100000f;

    //public Rigidbody2D standingFanRigidbody2D;
    public string targetTag = "teleporter";
    public string sceneName = "MenuNiveles";

    /*public FMOD.Studio.EventInstance ambience;
    public FMOD.Studio.PLAYBACK_STATE state;*/
    //public FMODUnity.StudioEventEmitter fmodEmitter;

    //private EventInstance fanEnginer;
    //private EventReference _fanEnginer;
    //private PARAMETER_DESCRIPTION Ventilador;

    private Animator animator;

    void Awake()
    {
        //fanEnginer.getParameterDescriptionByName ("Ventilador", out Ventilador);
    }
    void Start()
    {
        playerRigidbody2D = playerObject.GetComponent<Rigidbody2D>();
        //standingFanRigidbody2D = standingFanObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //fanEnginer = RuntimeManager.CreateInstance(_fanEnginer);

        /*RuntimeManager.AttachInstanceToGameObject(
            fanEnginer,
            GetComponent<Transform>(),
            GetComponent<Rigidbody>()
        );*/

        //fanEnginer.start();

        //ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Tutorial_Music");

        /*if(state != FMOD.Studio.PLAYBACK_STATE){
            ambience.start();
        }*/

        /*fmodEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
        
        if(fmodEmitter.IsPlaying() != null){
            fmodEmitter.Play();
        }*/
    }

    // Update is called once per frame
    void Update()
    {

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
            //Ventilador.setValue(vector * growSpeed);
            /*if(audioSource.pitch <= maxPitch){
                SetAudioSpeed(audioSource.pitch + pitchIncreaseRate);
            }*/
        }
    }

    public void PlayerController()
    {
        
    }

    public void SetAudioSpeed(float speed)
    {
        audioSource.pitch = speed;
    }

    public void OnButtonDown() {
        isHolding = true;
    }

    public void OnButtonUp() {
        isHolding = false;
        //SetAudioSpeed(audioSource.pitch - pitchIncreaseRate);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(targetTag)){
            SceneManager.LoadScene(sceneName);
            Debug.Log(collision.gameObject.tag);
            //fmodEmitter.Stop();
        }else {
            animator.SetTrigger("PlayDeath");
            Invoke("RestartLevel", 0.2f);
            //ambience.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        // Reinicia el nivel después de 2 segundos
    }

    // Método para reiniciar el nivel
    public void RestartLevel()
    {
        Destroy(playerObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
