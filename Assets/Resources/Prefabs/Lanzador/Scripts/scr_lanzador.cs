using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_lanzador : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        GameObject padre =  GameObject.Find("Lanzador");
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 45.0f;
        mousePos.y = 230;
        padre.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
