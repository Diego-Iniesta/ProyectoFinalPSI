using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CambiarImagen : MonoBehaviour
{
    public Image imagen;
    public void AbrirGaleria()
    {
        StartCoroutine(AbrirGaleriaCoroutine());
    }
    IEnumerator AbrirGaleriaCoroutine()
    {
        yield return null;
        if (Application.platform == RuntimePlatform.Android)
        {
            NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
            {
                if (path != null)
                {
                    StartCoroutine(CargarImagen(path));
                }
            });
            if (permission != NativeGallery.Permission.Granted)
            {
                Debug.LogError("Permiso denegado para acceder a la galeria!");
            }
        }
        else
        {
            Debug.LogError("Esta funcion solo esta disponible en Android");
        }
    }
    IEnumerator CargarImagen(string path)
    {
        var www = new WWW("file://" + path);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            Texture2D textura = new Texture2D(1, 1);
            www.LoadImageIntoTexture(textura);
            Sprite sprite = Sprite.Create(textura, new Rect(0, 0, textura.width, textura.height), Vector2.zero);
            imagen.sprite = sprite;

            Manager.Instance.fotoPerfilUsuarioActual = sprite;
        }
        else
        {
            Debug.LogError("Error al cargar la imagen: " + www.error);
        }
    }
}

