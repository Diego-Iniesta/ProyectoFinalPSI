using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenPerfil : MonoBehaviour
{
    public Image imagenPerfil;

    void Update()
    {
        if (Manager.Instance.fotoPerfilUsuarioActual != null)
        {
            imagenPerfil.sprite = Manager.Instance.fotoPerfilUsuarioActual;
        }
    }
}