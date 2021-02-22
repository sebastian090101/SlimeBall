using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bolita_extra : MonoBehaviour
{

    AudioSource Controler_AS;
    private void Start()
    {
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/mas_pelotita"));
            Destroy(transform.gameObject);
            GameObject.Find("Lanzar").GetComponent<scr_lanzador>().cambiar_numero_rebotador(true);
        }
    }
}
