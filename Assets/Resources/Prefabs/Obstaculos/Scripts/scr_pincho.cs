using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pincho : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<scr_player>().matar_player(true);
        }
    }
}
