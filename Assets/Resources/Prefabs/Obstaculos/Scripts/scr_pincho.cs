using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pincho : MonoBehaviour
{
    GameObject btn_pause;
    GameObject lanzador;

    private void Start()
    {
        btn_pause = GameObject.Find("Boton_Pausa");
        lanzador = GameObject.Find("Lanzar");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<scr_player>().matar_player(true);
        }
    }
}
