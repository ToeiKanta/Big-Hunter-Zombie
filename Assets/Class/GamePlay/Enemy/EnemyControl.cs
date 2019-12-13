using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private int health = 30;
    [SerializeField]
    private int headDamage = 10;
    [SerializeField]
    private int bodyDamage = 5;
    [SerializeField]
    private TextMeshProUGUI healthBar;
    [SerializeField]
    private TextMeshProUGUI healthDiffTxt;
    private bool isDie = false;
    // Start is called before the first frame update
    void Start()
    {
        updateHealthBar();
        healthDiffTxt.text = "";
    }

    public void takeDamage(string part){
        int damageTaken = 0;
        switch(part){
            case "Head":
                damageTaken = headDamage;break;ใช่
            case "Body":
                damageTaken = bodyDamage;break;
        }
        health -= damageTaken;
        if(health <= 0){
            health = 0;
            Debug.Log("DEAD");
            isDie = true;
        }
        StartCoroutine(showHealthDiff(-damageTaken));
        updateHealthBar();
    }

    IEnumerator showHealthDiff(int healthDiff){
        healthDiffTxt.text = healthDiff.ToString();
        yield return new WaitForSeconds(0.7f);
        healthDiffTxt.text = "";
    }
    void updateHealthBar(){
        healthBar.text = "HP : " + health.ToString();
    }

}
