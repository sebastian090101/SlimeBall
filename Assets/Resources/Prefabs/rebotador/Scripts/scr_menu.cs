using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_menu : MonoBehaviour, IPointerClickHandler
{
    public bool girar;
    float velocity = -25;

    private void Start()
    {
        girar = false;
    }

    void Update()
    {
        if( girar)
        {
            transform.RotateAround(transform.position, Vector3.back, velocity * Time.deltaTime);
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        velocity = 0;
    }
}
