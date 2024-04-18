using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateUI : MonoBehaviour
{
    [SerializeField] private GameObject botonera;
    [SerializeField] private GameObject fondo;
    [SerializeField] private GameObject menuDes;
    [SerializeField] private GameObject menuInicio;
    [SerializeField] private GameObject menuRes;
    private Vector3 originalPosition;
    private CanvasGroup fondoCanvasGroup;

    void Start()
    {
        originalPosition = botonera.GetComponent<RectTransform>().anchoredPosition;
        fondoCanvasGroup = fondo.GetComponent<CanvasGroup>();
    }

    public void Ajustes()
    {
        if (LeanTween.isTweening(botonera))
        {
            LeanTween.cancel(botonera);
        }

        if (Mathf.Approximately(botonera.GetComponent<RectTransform>().anchoredPosition.y, originalPosition.y))
        {
            LeanTween.moveY(botonera.GetComponent<RectTransform>(), 447, 0.5f).setEase(LeanTweenType.easeOutBounce);
        }
        else
        {
            LeanTween.moveY(botonera.GetComponent<RectTransform>(), originalPosition.y, 0.5f).setEase(LeanTweenType.easeOutBounce);
        }
    }
    public void MenuDesarrollador()
    {
        LeanTween.scale(menuDes.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0.5f, 0.5f);
        fondoCanvasGroup.blocksRaycasts = true;
    }
    public void CerrarMenuDes()
    {
        LeanTween.scale(menuDes.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0f, 0.5f);
        fondoCanvasGroup.blocksRaycasts = false;
    }
    public void MenuInicio()
    {
        LeanTween.scale(menuInicio.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0.5f, 0.5f);
        fondoCanvasGroup.blocksRaycasts = true;
    }
    public void CerrarMenuInicio()
    {
        LeanTween.scale(menuInicio.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0f, 0.5f);
        fondoCanvasGroup.blocksRaycasts = false;
    }
    public void MenuRes()
    {
        LeanTween.scale(menuRes.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0.5f, 0.5f);
        fondoCanvasGroup.blocksRaycasts = true;
    }
    public void CerrarMenuRes()
    {
        LeanTween.scale(menuRes.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0f, 0.5f);
        fondoCanvasGroup.blocksRaycasts = false;
    }
}
