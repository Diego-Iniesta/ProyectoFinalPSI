using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AnimateUI2 : MonoBehaviour
{
    [SerializeField] private GameObject tienda;
    [SerializeField] private GameObject perfil;
    [SerializeField] private GameObject juego;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject ranking;
    [SerializeField] private GameObject campaña;
    [SerializeField] private GameObject coliseo;
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;
    public Image telonOscuro;
    void Start()
    {
        
    }
    
    public void Tienda()
    {
        LeanTween.scale(tienda.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
    }
    public void CerrarTienda()
    {
        LeanTween.scale(tienda.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
    }
    public void Perfil()
    {
        LeanTween.scale(perfil.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
    }
    public void CerrarPerfil()
    {
        LeanTween.scale(perfil.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
    }
    public void Juego()
    {
        RectTransform rectTransform = juego.GetComponent<RectTransform>();
        Vector3 originalPosition = rectTransform.localPosition;
        Vector3 targetPosition = originalPosition + new Vector3(0, -1102f, 0); // Desplazamiento hacia abajo

        LeanTween.move(rectTransform, targetPosition, 0.5f)
            .setEase(LeanTweenType.easeOutBounce)
            .setDelay(0.1f);
    }
    public void CerrarJuego()
    {
        RectTransform rectTransform = juego.GetComponent<RectTransform>();
        Vector3 originalPosition = rectTransform.localPosition;
        Vector3 targetPosition = originalPosition + new Vector3(0, 1102f, 0); // Desplazamiento hacia abajo

        LeanTween.move(rectTransform, targetPosition, 0.5f)
            .setEase(LeanTweenType.easeInBack)
            .setDelay(0.1f);
    }
    public void Tutorial()
    {
        LeanTween.scale(tutorial.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
    }
    public void CerrarTutorial()
    {
        LeanTween.scale(tutorial.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
    }
    public void Ranking()
    {
        LeanTween.scale(ranking.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
    }
    public void CerrarRanking()
    {
        LeanTween.scale(ranking.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
    }
    public void Campaña()
    {
        LeanTween.scale(campaña.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
    }
    public void CerrarCampaña()
    {
        LeanTween.scale(campaña.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
    }
    public void Coliseo()
    {
        LeanTween.scale(coliseo.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutBack);
    }
    public void CerrarColiseo()
    {
        LeanTween.scale(coliseo.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.3f);
    }
    public void MostrarOpcionesDificultad()
    {
        telonOscuro.gameObject.SetActive(true);
        LeanTween.alpha(telonOscuro.rectTransform, 0.8f, 0.5f);
        MostrarImagen(imagen1);
        MostrarImagen(imagen2);
        MostrarImagen(imagen3);
    }

    public void SeleccionarDificultad()
    {
        OcultarImagen(imagen1);
        OcultarImagen(imagen2);
        OcultarImagen(imagen3);
        LeanTween.alpha(telonOscuro.rectTransform, 0f, 0.5f).setOnComplete(() => telonOscuro.gameObject.SetActive(false));
    }

    private void MostrarImagen(Image imagen)
    {
        imagen.gameObject.SetActive(true);
        LeanTween.alpha(imagen.rectTransform, 1f, 1f);
        LeanTween.moveY(imagen.rectTransform, 0f, 1f).setEase(LeanTweenType.easeOutExpo);
    }

    private void OcultarImagen(Image imagen)
    {
        LeanTween.alpha(imagen.rectTransform, 0f, 1f).setOnComplete(() => imagen.gameObject.SetActive(false));
        LeanTween.moveY(imagen.rectTransform, 200f, 1f).setEase(LeanTweenType.easeInExpo);
    }

}
