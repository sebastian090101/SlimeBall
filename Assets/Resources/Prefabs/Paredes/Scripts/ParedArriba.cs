using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedArriba : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        GameObject prefab_player_fake = Resources.Load<GameObject>("Prefabs/Lanzador/Prefab_Player/Player_Fake");
        GameObject awa = transform.GetChild(0).gameObject;
        Instantiate(prefab_player_fake, new Vector3(awa.transform.position.x, awa.transform.position.y, 50), Quaternion.identity);
    }
}
