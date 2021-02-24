using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_menu_perder : MonoBehaviour
{
    public void Restart()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;

    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu_Niveles");
        Time.timeScale = 1;
    }
}
