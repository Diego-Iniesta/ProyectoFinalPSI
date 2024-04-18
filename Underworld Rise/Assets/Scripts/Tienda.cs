using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class Tienda : MonoBehaviour
{
    public Image imagenItem;
    public TextMeshProUGUI nombreItem;
    public TextMeshProUGUI descripcionItem;
    public TextMeshProUGUI costoItem;
    public TextMeshProUGUI oroDisponible;
    public GameObject panelAlerta;
    public GameObject costoText;

    public List<Item> itemsDisponibles;
    private int indiceItemSeleccionado = -1;

    public TextMeshProUGUI textoOro;

    void Start()
    {
        MostrarOro();
        costoText.SetActive(false);
    }

    public void SeleccionarItem(int indice)
    {
        indiceItemSeleccionado = indice;
        MostrarItemSeleccionado();
        MostrarCostoText();
    }

    public void ComprarItem()
    {
        if (indiceItemSeleccionado != -1)
        {
            Item itemSeleccionado = itemsDisponibles[indiceItemSeleccionado];
            if (itemSeleccionado.costo <= Manager.Instance.oroJugador)
            {
                Manager.Instance.oroJugador -= itemSeleccionado.costo;
                MostrarOro();
                MostrarItemSeleccionado();
                MostrarAlerta("Compra realizada con éxito");
            }
            else
            {
                MostrarAlerta("No tienes suficiente oro");
            }
        }
    }

    void MostrarItemSeleccionado()
    {
        if (indiceItemSeleccionado != -1)
        {
            Item itemSeleccionado = itemsDisponibles[indiceItemSeleccionado];
            imagenItem.sprite = itemSeleccionado.sprite;
            nombreItem.text = itemSeleccionado.nombre;
            descripcionItem.text = itemSeleccionado.descripcion;
            costoItem.text = itemSeleccionado.costo.ToString();
        }
        else
        {
            imagenItem.sprite = null;
            nombreItem.text = "";
            descripcionItem.text = "";
            costoItem.text = "";
        }
    }

    void MostrarOro()
    {
        oroDisponible.text = "Oro: " + Manager.Instance.oroJugador.ToString();
        textoOro.text = "Oro: " + Manager.Instance.oroJugador.ToString();
    }
    void MostrarCostoText()
    {
        costoText.SetActive(true);
    }
    void MostrarAlerta(string mensaje)
    {
        panelAlerta.SetActive(true);
        panelAlerta.GetComponentInChildren<TextMeshProUGUI>().text = mensaje;
        StartCoroutine(OcultarAlerta());
    }

    IEnumerator OcultarAlerta()
    {
        yield return new WaitForSeconds(3.5f);
        panelAlerta.SetActive(false);
    }
}

[System.Serializable]
public class Item
{
    public string nombre;
    public string descripcion;
    public int costo;
    public Sprite sprite;
}
