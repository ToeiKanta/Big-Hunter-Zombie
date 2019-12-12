using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    [SerializeField]
    private GameObject output;
    [SerializeField]
    private GameObject ammo;
    private bool isPressed = false;
    private Vector3 initPos;

    private float force;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed){
            dragToShoot();
        }
    }
    
    private void dragToShoot(){
        Vector3 mousePos = Camera.main.WorldToScreenPoint (Input.mousePosition);
        if(mousePos != initPos){ // this condition prevent rotation when just click the screen
            var x = mousePos.x - initPos.x;
            var y = mousePos.y - initPos.y;
            Vector2 direction = new Vector2(x,y);
            transform.up = direction;
            //shot length (force)
            force = Mathf.Sqrt((x*x)+(y*y));
        }
    }
    private void shoot(){
        GameObject ammo_ = Instantiate(ammo,output.transform.position,Quaternion.identity);
        ammo_.GetComponent<Rigidbody2D>().AddForce( -transform.up * force/100f);
    }
    private void OnMouseDown() {
        initPos = Camera.main.WorldToScreenPoint (Input.mousePosition);
        isPressed = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        shoot();
    }

    
}
