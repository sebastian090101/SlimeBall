using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.Mathematics.math;

public class scr_giro : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    // Variables de uso continuo
    float angulo;
    GameObject padre;
    Vector3 mousepos_update = Vector3.zero;
    bool presionando;
    float Contador = 0;

    // Start is called before the first frame update
    void Start()
    {
        padre = GameObject.Find("Lanzador");
    }

    void Update()
    {
        if (presionando)
        {
            Contador += Time.deltaTime;
            Vector3 crecer = new Vector3(0.2f * Time.deltaTime, 0.2f * Time.deltaTime, 1);
            transform.localScale += crecer;
        }
        else
        {
            Contador = 0;
            transform.localScale = Vector3.one;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // posicion del dedo cuando es precionado el objeto
        mousepos_update = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if( mousepos_update.x > transform.position.x)
        {
            angulo = 200.0f;
        }
        else if (mousepos_update.x < transform.position.x)
        {
            angulo = -200.0f;
        }
        else
        {
            
        }
        //modificar la rotacion en Z del padre
        padre.transform.RotateAround(padre.transform.position, Vector3.back, angulo * Time.deltaTime);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // cuando se termina la accion volver a 0 el angulo de jiro.
        angulo = 0.0f;
        if (Contador > 3)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Lanzador/Prefab_Player/Player"),transform.position , Quaternion.identity);
        }
        presionando = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        presionando = true;
    }
}
