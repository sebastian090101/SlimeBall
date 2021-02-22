using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_lanzador_camera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_Fake")
        {
            Destroy(collision.gameObject);
            // sumar vida a objeto lanzador
            GameObject.Find("Lanzar").transform.GetComponent<scr_lanzador>().cambiar_numero_rebotador(true);
        }
    }
}
