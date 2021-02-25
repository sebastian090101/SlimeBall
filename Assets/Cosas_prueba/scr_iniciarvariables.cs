using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_iniciarvariables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Vidas", 5);

            actualizar_contador();

        
    }

    public void actualizar_contador()
    {
        transform.GetComponent<Text>().text = PlayerPrefs.GetInt("Vidas") + " Vidas";
    }

}
