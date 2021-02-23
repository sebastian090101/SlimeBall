using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_menu_win : MonoBehaviour
{
    public Text rebotes, segundo;
    GameObject controler;
    private void Awake()
    {
        controler = GameObject.Find("Boton_Pausa");
    }

    private void Start()
    {
        rebotes.text = "" + controler.GetComponentInChildren<Scr_btn_pausa>().rebotes_totales;
        segundo.text = controler.GetComponentInChildren<Scr_btn_pausa>().time + " Sec";
    }

    public void btn_menu()
    {
        SceneManager.LoadScene("Menu_Niveles");
        Time.timeScale = 1;
    }

    public void btn_restart()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }
    public void btn_next()
    {
        Scene scene_index = SceneManager.GetActiveScene();
        int index = scene_index.buildIndex;
        index+=1;
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }



}
