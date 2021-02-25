using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource Controler_AS;
    float tiempo_vida = 0.0f;
    bool powerup = false;
    int rebotes_consecutivos = 0;

    Vector2 a = Vector2.zero; Vector2 b = Vector2.zero;
    Vector2 resultado = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        //Sonido del player al explotar
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        // Obetenemos el objeto que nos da el angulo de tiro 
        GameObject lanzador_child = GameObject.Find("Lanzar").transform.GetChild(0).gameObject;

        Vector3 posicion_final   = lanzador_child.GetComponentInChildren<scr_instanciar_lanzador>().mousepos_update;
        Vector3 posicion_inicial = lanzador_child.GetComponentInChildren<scr_instanciar_lanzador>().posicion_inicial;

        Vector3 uwu = new Vector3(posicion_final.x - posicion_inicial.x, posicion_final.y - posicion_inicial.y, 50);

        rb.AddRelativeForce(uwu*50);
        StartCoroutine("Direccion");


    }

    private void Update()
    {
        tiempo_vida += Time.deltaTime;
        if (tiempo_vida >= 10.0f)
        {
            matar_player(false);
        }
    }


    public void matar_player(bool muerte)
    {
        Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/pop_player"));
        Instantiate(Resources.Load("Particle_Systems/Explosion_player"), transform.position, transform.rotation);
        Destroy(transform.gameObject);
        if (!muerte)
        {
            GameObject.Find("Lanzar").GetComponent<scr_lanzador>().cambiar_numero_rebotador(true);
        }
        else
        {
            if (bolitas()== 1)
            {
                GameObject.Find("Boton_Pausa").GetComponent<Scr_btn_pausa>().perder();
            }
        }
        
    }
    public void set_powerup(bool awa)
    {
        this.powerup = awa;
    }
    public bool get_powerup()
    {
        return powerup;
    }

    int bolitas()
    {
        int a = GameObject.Find("Lanzar").GetComponent<scr_lanzador>().bolitas;
        int b = GameObject.FindGameObjectsWithTag("Player").Length;
        int c = GameObject.FindGameObjectsWithTag("Player_Fake").Length;

        return a+b+c;
    }
    

    void sumar_velocidad()
    {
        rb.AddForce(resultado*500);
    }


    IEnumerator Direccion()
    {
        a = transform.position;
            yield return new WaitForSeconds(0.1f);
        b = transform.position;

            yield return null;
        resultado = new Vector2(b.x - a.x , b.y - b.x );
            StartCoroutine("Direccion");
    }

    IEnumerator Rebotes_Consecutivos()
    {
        int aux = rebotes_consecutivos;
        yield return new WaitForSeconds(2f);
        
        yield return null;

        if (aux == rebotes_consecutivos)
        {
            aux = 0;
        }
        else if (aux > rebotes_consecutivos && aux < 4)
        {
            aux += 1;
        }
        else
        {
            sumar_velocidad();
        }

        StartCoroutine("Rebotes_COnsecutivos");
    }
}
