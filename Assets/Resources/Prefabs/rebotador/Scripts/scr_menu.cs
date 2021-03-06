﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_menu : MonoBehaviour
{
    Collision2D auxiliar;
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
            auxiliar = collision;
            bool powerup = collision.gameObject.GetComponent<scr_player>().get_powerup();
            if (!powerup)
            {
                vidas_rebotador -= 1;
                cambiar_numero_rebotador();
                controlador.GetComponentInChildren<Scr_btn_pausa>().rebotes_totales += 1;
                Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/rebote"));
            }
            else
            {
                Destruir_Rebotador();
            }
            collision.gameObject.GetComponent<scr_player>().rebotes_consecutivos += 1;
            // aumento velocidad del player
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
            Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/pop_rebotador"));
            Instantiate(Resources.Load("Particle_Systems/Explosion_Rebotador"), transform.position, transform.rotation);
            Destruir_Rebotador();
        }
        else
        {
            direcion += "infinito";
        }
        obj_numero.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>(direcion);
    }


    void Destruir_Rebotador()
    {
        Vector3 posicion = transform.position;
        Destroy(transform.gameObject);

        int a = UnityEngine.Random.Range(0, 99);

    if (a < 20)
        {
            instanciar_nuevo_objeto(posicion);
        }
    }

    void instanciar_nuevo_objeto(Vector3 pos)
    {
        int a = UnityEngine.Random.Range(0, 99);
        if(a > 9)
        {
            Instantiate(Resources.Load("Prefabs/rebotador/Prefabs_Reb/circulo_instanciado"), pos , Quaternion.identity);
        }
        else {
            Instantiate(Resources.Load("Prefabs/Obstaculos/pincho"), pos, Quaternion.identity);
        }
    }
    
}
