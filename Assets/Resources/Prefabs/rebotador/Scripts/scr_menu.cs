using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_menu : MonoBehaviour, IPointerClickHandler
{
    float velocity = -25;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.back, velocity * Time.deltaTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        velocity = 0;
    }
}
