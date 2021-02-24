using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_powerup : MonoBehaviour
{
    AudioSource Controler_AS;
    private void Start()
    {
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/powerup"));
            collision.gameObject.GetComponent<scr_player>().set_powerup(true);
            Destroy(transform.gameObject);
        }
    }

}
