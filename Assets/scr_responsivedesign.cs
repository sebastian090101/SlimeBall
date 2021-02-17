using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_responsivedesign : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject awa =  GameObject.FindGameObjectWithTag("Respawn");

            RectTransform uwu = Canvas.FindObjectOfType<RectTransform>();
            float x = Canvas.FindObjectOfType<RectTransform>().transform.position.x;
            float y = Canvas.FindObjectOfType<RectTransform>().transform.position.y;
            awa.transform.transform.position = uwu.transform.position;

            // transform.position = posicion_instanciar.transform.position;
        }
    }
}
