using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_btn_pausa : MonoBehaviour
{

    public float time = 0.0f;
    public int rebotes_totales = 0;

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void pausa()
    {
        Time.timeScale = 0;
        //destruimos boton pause si ya existe
        if (GameObject.Find("menu_pause(Clone)"))
        {
            GameObject menu_rebotador = GameObject.Find("menu_pause(Clone)");
            Destroy(menu_rebotador);
        }
        //Instanciamos un menu de pause
        GameObject prefab_menu_rebotadores = Resources.Load<GameObject>("Prefabs/Menus/Menu_Pausa/menu_pause");
        GameObject canvas = GameObject.Find("Canvas");
        Instantiate(prefab_menu_rebotadores, new Vector3(canvas.transform.position.x , canvas.transform.position.y , 0), transform.rotation, canvas.transform );
    }

    void sumar_rebote()
    {
        rebotes_totales += 1;
    }
}
