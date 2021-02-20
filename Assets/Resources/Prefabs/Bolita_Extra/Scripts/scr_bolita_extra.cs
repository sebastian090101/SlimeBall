using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bolita_extra : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(transform.gameObject);
            GameObject.Find("Lanzar").GetComponent<scr_lanzador>().cambiar_numero_rebotador(true);
        }
    }
}
