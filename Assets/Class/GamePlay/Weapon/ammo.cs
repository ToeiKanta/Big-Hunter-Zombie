using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isColission = false;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(!isColission){
            transform.up = rb.velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("wall")){
            Destroy(gameObject);
        }else if(other.CompareTag("Enemy")){
            // Debug.Log("Hit");
            isColission = true;
            stick();
            takeDamage(other);
        }
    }
    private void takeDamage(Collider2D other){
        var enemy = other.gameObject.GetComponentInParent<EnemyControl>();
        if (other.gameObject.name == "Head"){
            enemy.takeDamage("Head");
        }
        if (other.gameObject.name == "Body"){
            enemy.takeDamage("Body");
        }
    }
    private void stick(){
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
