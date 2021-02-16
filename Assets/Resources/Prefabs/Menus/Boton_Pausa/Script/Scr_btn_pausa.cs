using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_btn_pausa : MonoBehaviour
{
  
    
    public void pausa()
    {
        Time.timeScale = 0;
        //Instanciamos un menu de creacion 
        GameObject prefab_menu_rebotadores = Resources.Load<GameObject>("Prefabs/Menus/Menu_Pausa/menu_pause");
        Instantiate(prefab_menu_rebotadores, new Vector3(360,760 ,0), transform.rotation, GameObject.Find("Canvas").transform);
    }
}
