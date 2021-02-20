using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerFake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(0, -1) * 50000);
    }
}
