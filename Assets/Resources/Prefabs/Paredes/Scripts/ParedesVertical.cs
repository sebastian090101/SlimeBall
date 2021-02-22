using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesVertical : MonoBehaviour
{
    GameObject controlador;
    AudioSource Controler_AS;
    private void Start()
    {
        controlador = GameObject.Find("Boton_Pausa");
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controlador.GetComponentInChildren<Scr_btn_pausa>().rebotes_totales += 1;
            Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/rebote"));
        }
    }
}
