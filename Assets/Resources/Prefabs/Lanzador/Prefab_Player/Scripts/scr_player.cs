using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 angulo_tiro = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject lanzador;
        Transform awa;
        lanzador = GameObject.Find("Lanzador");
        awa = lanzador.transform.GetChild(0);
        angulo_tiro = new Vector3(
            awa.transform.position.x - lanzador.transform.position.x ,
            awa.transform.position.y - lanzador.transform.position.y );
        angulo_tiro.Normalize();

        rb.AddRelativeForce(angulo_tiro*50000);
        
    }

}
