using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour
{
    Rigidbody2D rb;
    TrailRenderer tr;
    Vector2 angulo_tiro = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();

        // Obetenemos el objeto que nos da el angulo de tiro 
        GameObject lanzador_child = GameObject.Find("Lanzar").transform.GetChild(0).gameObject;

        Vector3 posicion_final   = lanzador_child.GetComponentInChildren<scr_instanciar_lanzador>().mousepos_update;
        Vector3 posicion_inicial = lanzador_child.GetComponentInChildren<scr_instanciar_lanzador>().posicion_inicial;

        Vector3 uwu = new Vector3(posicion_final.x - posicion_inicial.x, posicion_final.y - posicion_inicial.y, 50);

        rb.AddRelativeForce(uwu*50);
        
    }

}
