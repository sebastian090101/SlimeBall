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
        // por el momento no hace nada xd 
    }

    public void btn_restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
    public void btn_next()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }



}
