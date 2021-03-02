using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerFake : MonoBehaviour
{

    float tiempo_vida = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(0, -1) * 50000);
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
        Destroy(transform.gameObject);
        if (!muerte)
        {
            GameObject.Find("Lanzar").GetComponent<scr_lanzador>().cambiar_numero_rebotador(true);
        }
    }
}
