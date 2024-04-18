using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string nombreUsuarioActual;
    public string correoUsuarioActual;
    public string contraseñaUsuarioActual;
    public Sprite fotoPerfilUsuarioActual;
    public int oroJugador; // Variable para almacenar la cantidad de oro del jugador

    public List<string> usuarios = new List<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        usuarios.Add("Diego");
    }
}
