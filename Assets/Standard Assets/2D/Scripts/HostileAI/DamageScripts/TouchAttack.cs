using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class TouchAttack : MonoBehaviour {

    //========================================================================================//
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.gameObject.tag == "Player")
        {
            collision.SendMessage("TakeDamage");
        }
    }
    //========================================================================================//
}
