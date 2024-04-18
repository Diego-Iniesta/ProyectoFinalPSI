using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NombreUsuario : MonoBehaviour
{
    public TextMeshProUGUI textoNombreUsuario;

    void Start()
    {
        if (Manager.Instance != null)
        {
            textoNombreUsuario.text = Manager.Instance.nombreUsuarioActual;
        }
    }
}
