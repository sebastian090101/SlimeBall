using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Instaciar_MR : MonoBehaviour, IPointerClickHandler
{
    public float z;
    GameObject prefab_menu_rebotadores;

    public  void OnPointerClick(PointerEventData data)
    {
        Vector3 posicion_mouse = Input.mousePosition;
        posicion_mouse.z = z;

        // Destruimos el anterior si es que existe
        if (GameObject.Find("Menu_Rebotador(Clone)"))
        {
            GameObject menu_rebotador = GameObject.Find("Menu_Rebotador(Clone)");
            Destroy(menu_rebotador);
        }
        //Instanciamos un menu de creacion 
        prefab_menu_rebotadores = Resources.Load<GameObject>("Prefabs/rebotador/Menu_Rebotador");
        Instantiate(prefab_menu_rebotadores, posicion_mouse, transform.rotation);
    }
}
