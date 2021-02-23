using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource Controler_AS;
    float tiempo_vida = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        // Obetenemos el objeto que nos da el angulo de tiro 
        GameObject lanzador_child = GameObject.Find("Lanzar").transform.GetChild(0).gameObject;

        Vector3 posicion_final   = lanzador_child.GetComponentInChildren<scr_instanciar_lanzador>().mousepos_update;
        Vector3 posicion_inicial = lanzador_child.GetComponentInChildren<scr_instanciar_lanzador>().posicion_inicial;

        Vector3 uwu = new Vector3(posicion_final.x - posicion_inicial.x, posicion_final.y - posicion_inicial.y, 50);

        rb.AddRelativeForce(uwu*50);
        
    }

    private void Update()
    {
        tiempo_vida += Time.deltaTime;
        if (tiempo_vida >= 10.0f)
        {
            Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/pop"));
            Instantiate(Resources.Load("Particle_Systems/Explosion_player"),transform.position, transform.rotation);
            Destroy(transform.gameObject);
            GameObject.Find("Lanzar").GetComponent<scr_lanzador>().cambiar_numero_rebotador(true);
        }
    }

}
