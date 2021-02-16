using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Botones_Rebote : MonoBehaviour, IPointerClickHandler
{

    public int ID_Rebotador;
    GameObject menu_rebotador;

    public void OnPointerClick(PointerEventData data)
    {
        Instaciar_Rebotador(ID_Rebotador);
    }

    void Instaciar_Rebotador(int num)
    {
        switch (num)
        {
            case 1:
                objeto(Resources.Load<GameObject>("Prefabs/rebotador/Prefabs_Reb/rebotador1"));
                break;
            case 2:
                objeto(Resources.Load<GameObject>("Prefabs/rebotador/Prefabs_Reb/rebotador2"));
                break;
            case 3:
                objeto(Resources.Load<GameObject>("Prefabs/rebotador/Prefabs_Reb/rebotador3"));
                break;
            case 4:
                objeto(Resources.Load<GameObject>("Prefabs/rebotador/Prefabs_Reb/rebotador4"));
                break;
            default:
                break;
        }
    }


    //Assets/Resources/Prefabs/rebotador/Prefabs_Reb/rebotador1.prefab
    void objeto(GameObject uwu)
    {
        Vector3 pos = new Vector3(0,0,0);
        if (GameObject.Find("Menu_Rebotador(Clone)"))
        {
            menu_rebotador = GameObject.Find("Menu_Rebotador(Clone)");
            pos = menu_rebotador.transform.position;
            pos.z = 50.0f;
        }
        Instantiate(uwu, pos, transform.rotation);
        Destroy(menu_rebotador);
    }
}


