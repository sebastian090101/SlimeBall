using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_lanzador : MonoBehaviour, IDragHandler
{
    GameObject barra_baja;
    GameObject padre;
    Vector3 mousePos = Vector3.one;
    GameObject canvas;

    private void Awake()
    {
        barra_baja = GameObject.Find("Paredes_prueba/Pared_Abajo");
        padre = GameObject.Find("Lanzar");
        canvas= GameObject.Find("Canvas");
    }

    private void Start() => padre.transform.position = new Vector3(canvas.transform.position.x, 0.0f + canvas.transform.position.y * 0.1f, 45.0f);

    public void OnDrag(PointerEventData eventData)
    {
        mousePos = new Vector3(eventData.position.x, 0.0f + canvas.transform.position.y*0.1f, 45.0f);
        padre.transform.position = mousePos;
    }
}
