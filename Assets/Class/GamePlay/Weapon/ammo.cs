using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    [SerializeField]
    private GameObject shootingLine;
    private GameObject[] tempLine = new GameObject[1000];
    private int count = 0;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "wall"){
            Destroy(gameObject);
        }
    }
}
