using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    void Update()
    {
        transform.up = (GetComponent<Rigidbody2D>().velocity);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "wall"){
            Destroy(gameObject);
        }
    }
}
