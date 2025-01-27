using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;

public class ControllerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isHolding = false; // Indica si el botón está siendo presionado
    [SerializeField] private EventReference audioEvent; // Evento de FMOD
    private FMOD.Studio.EventInstance audioInstance;

    private void Start()
    {
        // Crea una instancia del evento de audio
        audioInstance = RuntimeManager.CreateInstance(audioEvent);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true; // Activa el estado de presión
        audioInstance.start();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false; // Desactiva el estado de presión
        audioInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Handheld.Vibrate();
    }

    private void OnDestroy()
    {
        // Libera la instancia de audio al destruir el objeto
        audioInstance.release();
    }
}
