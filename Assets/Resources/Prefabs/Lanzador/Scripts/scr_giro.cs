using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.Mathematics.math;

public class scr_giro : MonoBehaviour, IDragHandler
{

    // Variables de uso continuo
    float angulo;
    GameObject padre;
    Vector3 mousepos_update = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        padre = GameObject.Find("Lanzador");
    }


    public void OnDrag(PointerEventData eventData)
    {
        // posicion del dedo cuando es precionado el objeto
        mousepos_update = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if( mousepos_update.x > transform.position.x)
        {
            angulo = 100.0f;
        }
        else if (mousepos_update.x < transform.position.x)
        {
            angulo = -100.0f;
        }
        else
        {
            
        }
        //modificar la rotacion en Z del padre
        padre.transform.RotateAround(padre.transform.position, Vector3.back, angulo * Time.deltaTime);
    }

}
