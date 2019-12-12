using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private bool isPressed = false;
    private Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed){
            Vector3 mousePos = Camera.main.WorldToScreenPoint (Input.mousePosition);
            Vector2 direction = new Vector2(
                mousePos.x - initPos.x,
                mousePos.y - initPos.y
            );
            transform.up = direction;
        }
    }
    private void OnMouseDown() {
        initPos = Camera.main.WorldToScreenPoint (Input.mousePosition);
        isPressed = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
    }
    private void rotateToDirection(){
        //rotation
        Vector3 mousePos = Input.mousePosition;
        Camera.main.WorldToScreenPoint (mousePos);

        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );
        transform.up = direction;
    }
}
