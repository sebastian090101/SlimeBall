using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_Control_Scenas_Inicio : MonoBehaviour
{
    public void Nivel_Prueba()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Niveles()
    {
        SceneManager.LoadScene("Menu_Niveles");
    }
    public void Instrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
    }
    public void Salir()
    {
        // Falta Agregar cuadro de dialogo "Seguro que deseas salir"
        Application.Quit();
    }

    public void Menu_Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Cargar_Nivel(string a)
    {
        SceneManager.LoadScene("Nivel_" + a);
    }

    public void Redes()
    {
        string url = "https://www.facebook.com/overskull.pe/";
        Application.OpenURL(url);
    }
}
