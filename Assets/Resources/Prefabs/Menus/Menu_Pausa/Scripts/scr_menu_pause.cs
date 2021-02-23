using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_menu_pause : MonoBehaviour
{
    public void reiniciar()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }
    public void btn_menu()
    {
        SceneManager.LoadScene("Menu_Niveles");
        Time.timeScale = 1;
    }
    public void continuar()
    {
        if (GameObject.Find("menu_pause(Clone)"))
        {
            GameObject menu_rebotador = GameObject.Find("menu_pause(Clone)");
            Destroy(menu_rebotador);
        }
        Time.timeScale = 1;
    }
}
