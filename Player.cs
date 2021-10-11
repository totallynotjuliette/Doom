using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform healthBar;
    public float playerHealth = 100;
    private float healthBarValue;
    //private Enemy enemyScript;
    public GameObject gameOverMenu;
    Vector3 healthBarScale;

    //bool isEnemyAttacking;


    void Start(){   

        gameOverMenu.SetActive(false);
        Time.timeScale = 1; //makes sure time is running as normal

    }

    void FixedUpdate(){   
        
    }

    public void playerHurtFromAttack(){

        //print("enemy attacking = true: on player script");
            playerHealth -= 20;
            healthBarValue = Remap(playerHealth, 0, 100, 0, 241);

            healthBarScale = healthBar.localScale;
            healthBarScale.x = healthBarValue;
            healthBar.localScale = healthBarScale;

            if(playerHealth <= 0){

                gameOverMenu.SetActive(true);
                Time.timeScale = 0; //pauses game (time not running)

            }

    }

    public static float Remap(float value, float from1, float to1, float from2, float to2) { // maps value from one range to another

        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;

    }
   
}
