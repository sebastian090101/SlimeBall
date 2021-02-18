using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scr_FInal : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.back, -10*Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            win();
        }
    }

    public void win()
    {
        Time.timeScale = 0;
        //destruimos boton pause si ya existe
        if (GameObject.Find("Menu_win(Clone)"))
        {
            GameObject menu_rebotador = GameObject.Find("Menu_win(Clone)");
            Destroy(menu_rebotador);
        }
        //Instanciamos un menu de pause
        GameObject prefab_menu_rebotadores = Resources.Load<GameObject>("Prefabs/Menus/Menu_Win/Menu_win");
        GameObject canvas = GameObject.Find("Canvas");
        Instantiate(prefab_menu_rebotadores, new Vector3(canvas.transform.position.x, canvas.transform.position.y, 0), Quaternion.identity, canvas.transform);
    }
}
