using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class src_control_niveles_desbloqueados : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        if (PlayerPrefs.GetInt("Niveles") >= int.Parse( transform.GetChild(0).GetComponent<Text>().text))
        {
            GetComponent<Button>().interactable = true;
            
        }

        
    }

}
