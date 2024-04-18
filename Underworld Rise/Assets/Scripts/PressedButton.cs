using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class PressedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button button;
    public Vector3 pressedScale = new Vector3(0.8f, 0.8f, 1f);
    public float duration = 0.1f; 
    public AudioClip pressSound;

    private Vector3 originalScale;
    private AudioSource audioSource;

    void Start()
    {
        originalScale = button.transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LeanTween.scale(button.gameObject, pressedScale, duration);
        if (pressSound != null)
        {
            audioSource.PlayOneShot(pressSound);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeanTween.scale(button.gameObject, originalScale, duration);
    }
}
