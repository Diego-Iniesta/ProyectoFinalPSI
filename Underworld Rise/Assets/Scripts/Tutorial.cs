using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] imagenes;
    public Button btnAnterior;
    public Button btnSiguiente;
    public Image[] marcadores;

    private int paginaActual = 0;

    void Start()
    {
        ActualizarPagina();
    }

    public void IrAPagina(int pagina)
    {
        paginaActual = pagina;
        ActualizarPagina();
    }

    public void IrAPaginaSiguiente()
    {
        paginaActual = Mathf.Min(paginaActual + 1, imagenes.Length - 1);
        ActualizarPagina();
    }

    public void IrAPaginaAnterior()
    {
        paginaActual = Mathf.Max(paginaActual - 1, 0);
        ActualizarPagina();
    }

    private void ActualizarPagina()
    {
        for (int i = 0; i < imagenes.Length; i++)
        {
            imagenes[i].SetActive(i == paginaActual);
        }

        btnAnterior.gameObject.SetActive(paginaActual > 0);
        btnSiguiente.gameObject.SetActive(paginaActual < imagenes.Length - 1);

        for (int i = 0; i < marcadores.Length; i++)
        {
            marcadores[i].color = (i == paginaActual) ? Color.white : Color.gray;
        }
    }
}

