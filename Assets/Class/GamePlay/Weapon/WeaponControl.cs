using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    //// Shoot
    [SerializeField]
    private GameObject output;
    [SerializeField]
    private GameObject ammo;
    [SerializeField]
    private GameObject shootingLine;

    ////Drag
    private bool isPressed = false;
    private Vector3 initPos;
    [SerializeField]
    private int force = 5;
    [SerializeField]
    private int dotAmount = 40;
    //tell shot line direction
    private Vector2 shotDirection;
    //dotSeparation
    [SerializeField]
    private int dotSeparation = 3;
    [SerializeField]
    private int dotShift = 3;
    //set dot amount
    private GameObject[] dots;
    // Start is called before the first frame update
    void Start()
    {
        initShotLine();
    }
    void initShotLine(){
        dots = new GameObject[dotAmount];
        for (int k = 0; k < dotAmount; k++) {
			dots[k] = Instantiate(shootingLine,transform.position,Quaternion.identity);
		}
        hideLineShotPredited();
    }
    // Update is called once per frame
    void Update()
    {
        if(isPressed){
            dragToShoot();
        }
    }
    
    private void dragToShoot(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); mousePos.z = 0;
        if(mousePos != initPos){ // this condition prevent rotation when just click the screen
            var x = initPos.x - mousePos.x;
            var y = initPos.y - mousePos.y;
            shotDirection = new Vector2(x,y);
            transform.up = shotDirection;
            showShotLinePredited();
        }
    }
    //this section will show shot line predited
    private void showShotLinePredited(){
        //will shot when force > 0.4f
        if(Mathf.Sqrt(Mathf.Pow(shotDirection.x,2) + Mathf.Pow(shotDirection.y,2)) > 0.4f){
            Vector2 shotForce = shotDirection * force;
            for (int k = 0; k < dotAmount; k++) { //Each point of the trajectory will be given its position
                float x1 = output.transform.position.x + shotForce.x * Time.fixedDeltaTime * (dotSeparation * k + dotShift);	//X position for each point is found
                float y1 = output.transform.position.y + shotForce.y * Time.fixedDeltaTime * (dotSeparation * k + dotShift) - (-Physics2D.gravity.y*3/2f * Time.fixedDeltaTime * Time.fixedDeltaTime * (dotSeparation * k + dotShift) * (dotSeparation * k + dotShift));	//Y position for each point is found
                dots [k].transform.position = new Vector3 (x1, y1, dots [k].transform.position.z);	//Position is applied to each point
            }
        }
    }
    private void shoot(){
        //can shot when force > 0.4f
        if(Mathf.Sqrt(Mathf.Pow(shotDirection.x,2) + Mathf.Pow(shotDirection.y,2)) > 0.4f){
            GameObject ammo_ = Instantiate(ammo,output.transform.position,Quaternion.identity);
            ammo_.GetComponent<Rigidbody2D>().velocity = ( shotDirection * force );
            hideLineShotPredited();
        }
    }

    private void hideLineShotPredited(){
        for (int k = 0; k < dotAmount; k++){
            dots [k].transform.position = new Vector3 (0,10,dots [k].transform.position.z);	//hide line shot
        }
    }
    private void OnMouseDown() {
        initPos = Camera.main.ScreenToWorldPoint (Input.mousePosition); initPos.z = 0;
        isPressed = true;
    }

    private void OnMouseUp()
    {
        shoot();
        isPressed = false;
    }

    
}
