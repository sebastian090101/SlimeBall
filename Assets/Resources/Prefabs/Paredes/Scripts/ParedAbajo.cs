using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedAbajo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Fake")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(new Vector2(-1, 0)* 50000);
        }
    }
}
