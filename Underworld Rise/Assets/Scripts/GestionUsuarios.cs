using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionUsuarios : MonoBehaviour
{
    public float alertaDuration = 3f;
    [Header("Campos para registro")]
    public TMP_InputField[] campos_registro;
    [Header("Campos inicio")]
    public TMP_InputField[] campos_inicio;

    [Header("Sistema Alertas")]
    public string[] texto_alertas;
    public TMP_Text alerta_actual;
 
    public void cambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void RegistrarUsuario()
    {
        bool camposVacios = false;

        for (int i = 0; i < campos_registro.Length; i++)
        {
            if (string.IsNullOrEmpty(campos_registro[i].text))
            {
                camposVacios = true;
                break;
            }
        }

        if (camposVacios)
        {
            StartCoroutine(MostrarAlerta(texto_alertas[0]));
            return;
        }

        if (Manager.Instance.usuarios.Contains(campos_registro[0].text))
        {
            StartCoroutine(MostrarAlerta(texto_alertas[1]));
        }
        else
        {
            Manager.Instance.usuarios.Add(campos_registro[0].text);
            Manager.Instance.nombreUsuarioActual = campos_registro[0].text;
            Manager.Instance.correoUsuarioActual = campos_registro[1].text;
            Manager.Instance.contraseñaUsuarioActual = campos_registro[2].text;
            cambiarEscena("Pantalla Principal");
        }
    }
    public void IniciarSesion()
    {
        bool camposVacios = false;

        for (int i = 0; i < campos_inicio.Length; i++)
        {
            if (string.IsNullOrEmpty(campos_inicio[i].text))
            {
                camposVacios = true;
                break;
            }
        }

        if (camposVacios)
        {
            StartCoroutine(MostrarAlerta(texto_alertas[0]));
            return;
        }

        if (Manager.Instance.usuarios.Contains(campos_inicio[0].text))
        {
            Manager.Instance.nombreUsuarioActual = campos_inicio[0].text;
            Manager.Instance.correoUsuarioActual = campos_inicio[1].text;
            Manager.Instance.contraseñaUsuarioActual = campos_inicio[2].text;
            cambiarEscena("Pantalla Principal");
        }
        else
        {
            StartCoroutine(MostrarAlerta(texto_alertas[2]));
        }
    }
    IEnumerator MostrarAlerta(string textoAlerta)
    {
        alerta_actual.text = textoAlerta;
        yield return new WaitForSeconds(alertaDuration);
        alerta_actual.text = "";
    }
}
