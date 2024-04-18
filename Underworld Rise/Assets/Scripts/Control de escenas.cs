using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controldeescenas : MonoBehaviour
{
    public void cambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
