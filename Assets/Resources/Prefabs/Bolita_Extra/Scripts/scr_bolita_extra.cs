using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bolita_extra : MonoBehaviour
{
    public int valor = 1;
    AudioSource Controler_AS;
    private void Start()
    {
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Prefabs/Bolita_Extra/Sprites/sumar" + valor);
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/mas_pelotita"));
            Destroy(transform.gameObject);
            for (int i = 0; i<valor ;i++)
            {
                GameObject.Find("Lanzar").GetComponent<scr_lanzador>().cambiar_numero_rebotador(true);
            }
        }
    }
}
