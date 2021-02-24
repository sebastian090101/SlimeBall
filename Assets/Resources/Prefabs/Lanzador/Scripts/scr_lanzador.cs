using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class scr_lanzador : MonoBehaviour, IDragHandler
{
    public GameObject obj_numero;
    GameObject barra_baja;
    GameObject padre, canvas, lanzador_camera;
    Vector3 mousePos = Vector3.one;

    public int bolitas = 1;

    private void Awake()
    {
        barra_baja = GameObject.Find("Paredes_prueba/Pared_Abajo");
        padre = GameObject.Find("Lanzar");
        canvas= GameObject.Find("Canvas");
        lanzador_camera = GameObject.Find("Lanzador_camera");
    }

    private void Start()
    {
        padre.transform.position = new Vector3(canvas.transform.position.x, +canvas.transform.position.y * 0.15f, 45.0f);
        lanzador_camera.transform.position = Camera.main.ScreenToWorldPoint(padre.transform.position);
        cambiar_numero_rebotador(true); cambiar_numero_rebotador(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePos = new Vector3(eventData.position.x,  canvas.transform.position.y*0.15f, 45.0f);
        padre.transform.position = mousePos;
        lanzador_camera.transform.position = Camera.main.ScreenToWorldPoint(padre.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Fake") 
        {
            Destroy(collision.gameObject);
        }
        
    }

    public void cambiar_numero_rebotador(bool positivo)
    {
        if (positivo)
        {
            bolitas += 1;
        }
        else{
            bolitas -= 1;
        }
        string direcion = "Prefabs/rebotador/Sprites/Numeros/";
        if (bolitas >= 0)
        {
            direcion += bolitas;
        }
        else
        {
            direcion += "infinito";
        }
        obj_numero.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(direcion);
    }

}
