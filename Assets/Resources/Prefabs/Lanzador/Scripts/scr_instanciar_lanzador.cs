using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.Mathematics.math;

public class scr_instanciar_lanzador : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Variables de uso continuo
    bool presionando;
    float Contador = 0;
    Vector3 mousepos_update = Vector3.zero;

    // Start is called before the first frame update
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

    public void OnPointerDown(PointerEventData data)
    {
        presionando = true;
        mousepos_update = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos_update.z = 45.0f;
    }


    public void OnPointerUp(PointerEventData data)
    {
        // cuando se termina la accion volver a 0 el angulo de jiro.
        if (Contador > 3)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Lanzador/Prefab_Player/Player"), mousepos_update, Quaternion.identity, GameObject.Find("Obstaculos").transform);
        }
        presionando = false;
    }
}
