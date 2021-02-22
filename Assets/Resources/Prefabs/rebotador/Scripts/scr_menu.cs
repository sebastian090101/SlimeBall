using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_menu : MonoBehaviour
{
    public int vidas_rebotador = 10;
    public float velocity = -25;
    public bool girar = false;
    // vairables del hijo numero
    public GameObject obj_numero;

    // almacenar cantidad de rebotes
    GameObject controlador;

    //variables de sonido
    AudioSource Controler_AS;


    private void Awake()
    {
        controlador = GameObject.Find("Boton_Pausa");
        cambiar_numero_rebotador();
    }

    private void Start()
    {
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }


    void Update()
    {
        if (girar)
        {
            transform.RotateAround(transform.position, Vector3.back, velocity * Time.deltaTime);
        }
    }
       

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vidas_rebotador -= 1;
            cambiar_numero_rebotador();
            controlador.GetComponentInChildren<Scr_btn_pausa>().rebotes_totales += 1;
            Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/rebote"));
        }
    }

    void cambiar_numero_rebotador()
    {
       
        String direcion = "Prefabs/rebotador/Sprites/Numeros/";
        if (vidas_rebotador > 0)
        {
            direcion += vidas_rebotador;
        }
        else if (vidas_rebotador == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            direcion += "infinito";
        }
        obj_numero.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>(direcion);
    }

}
