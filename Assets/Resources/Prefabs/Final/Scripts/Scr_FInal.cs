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
            SceneManager.LoadScene("Exit");
        }
    }
}
