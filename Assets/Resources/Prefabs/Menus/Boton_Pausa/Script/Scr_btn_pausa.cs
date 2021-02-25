using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_btn_pausa : MonoBehaviour
{

    public float time = 30.0f;
    float time_second = 0.0f;
    public int rebotes_totales = 0;

    private void Update()
    {
        time -= Time.deltaTime;
        time_second = (int)time;
        transform.GetChild(0).GetComponent<Text>().text = time_second + " : " + "00" + " s";
        if(time<0)
        {
            perder();
            time = 10.0f;
        }
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

    public void perder()
    {
        int a = PlayerPrefs.GetInt("Vidas");
        PlayerPrefs.SetInt("Vidas", a-1);
        Time.timeScale = 0;
        //destruimos menu perder si ya existe
        if (GameObject.Find("Menu_Loss(Clone)"))
        {
            GameObject menu_rebotador = GameObject.Find("Menu_Loss(Clone)");
            Destroy(menu_rebotador);
        }
        //Instanciamos un menu perder
        GameObject prefab_menu_rebotadores = Resources.Load<GameObject>("Prefabs/Menus/Menu_Perder/Menu_Loss");
        GameObject canvas = GameObject.Find("Canvas");
        Instantiate(prefab_menu_rebotadores, new Vector3(canvas.transform.position.x, canvas.transform.position.y, 0), 
                                                        transform.rotation, 
                                                        canvas.transform);
    }
}
