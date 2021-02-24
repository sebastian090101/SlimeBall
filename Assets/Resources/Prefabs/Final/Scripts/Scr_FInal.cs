using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scr_FInal : MonoBehaviour
{
    public int vidas_final = 0;
    public GameObject obj_numero;

    AudioSource Controler_AS;
    private void Start()
    {
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
        cambiar_numero_rebotador();
    }
    void Update()
    {
        //transform.RotateAround(transform.position, Vector3.back, -10*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            vidas_final -= 1;
            cambiar_numero_rebotador();
            Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/player_llega_final"));
            Destroy(collision.gameObject);
        }
    }

    public void win()
    {
        Time.timeScale = 0;
        //destruimos boton pause si ya existe
        if (GameObject.Find("Menu_win(Clone)"))
        {
            GameObject menu_rebotador = GameObject.Find("Menu_win(Clone)");
            Destroy(menu_rebotador);
        }
        //Instanciamos un menu de pause
        GameObject prefab_menu_rebotadores = Resources.Load<GameObject>("Prefabs/Menus/Menu_Win/Menu_win");
        GameObject canvas = GameObject.Find("Canvas");
        Instantiate(prefab_menu_rebotadores, new Vector3(canvas.transform.position.x, canvas.transform.position.y, 0), Quaternion.identity, canvas.transform);
        Instantiate(Resources.Load("Particle_Systems/Explosion_Rebotador"), transform.position, transform.rotation);
    }

    void cambiar_numero_rebotador()
    {

        string direcion = "Prefabs/rebotador/Sprites/Numeros/";
        if (vidas_final > 0)
        {
            direcion += vidas_final;
        }
        else if (vidas_final== 0)
        {
            win();
        }
        else
        {
            direcion += "infinito";
        }
        obj_numero.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>(direcion);
    }
}
