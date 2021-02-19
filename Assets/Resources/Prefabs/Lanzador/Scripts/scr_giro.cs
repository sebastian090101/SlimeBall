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

    // Start is called before the first frame update
    void Start()
    {
        padre = GameObject.Find("Lanzar");
    }


    public void OnDrag(PointerEventData eventData)
    {

        if(eventData.position.x > transform.position.x)
        {
            angulo = 100.0f;
        }
        else if (eventData.position.x < transform.position.x)
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
