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
    public Animator playerColorOverlayAnimator;

    public Enemy enemyScript;
    string enemyTag;

    //bool isEnemyAttacking;


    void Start(){   

        gameOverMenu.SetActive(false);
        Time.timeScale = 1; //makes sure time is running as normal

    }

    void FixedUpdate(){   
        
    }

    public void playerHurtFromAttack(){

        //print("enemy attacking = true: on player script");

        enemyTag = enemyScript.enemyTag;

             switch(enemyTag){

                    case "bull":
                        playerHealth -= enemyScript.enemyAttackStrength;
                        break;
                    
                    default:
                        playerHealth -= enemyScript.enemyAttackStrength;
                        break;

                }

            healthBarValue = Remap(playerHealth, 0, 100, 0, 241);
            playerColorOverlayAnimator.SetBool("isPlayerHurt", true);

            healthBarScale = healthBar.localScale;
            healthBarScale.x = healthBarValue;
            healthBar.localScale = healthBarScale;

            if(playerHealth <= 0){
                
                gameOverMenu.SetActive(true);
                print("true");
                Time.timeScale = 0; //pauses game (time not running)

            }    


    }

    public static float Remap(float value, float from1, float to1, float from2, float to2) { // maps value from one range to another

        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;

    }

    public void makeGameobjectLookAtPlayer(GameObject gameobjectThatLooksAtPlayer, Camera cam, Vector3 gameobjectToPlayerVector){

        gameobjectToPlayerVector = (gameobjectThatLooksAtPlayer.transform.position - cam.transform.position).normalized; 
        gameobjectThatLooksAtPlayer.transform.rotation = Quaternion.LookRotation(gameobjectToPlayerVector, Vector3.up);   //enemy rotation = line made from enemy to player
        //transform.rotation = cam.transform.rotation;                                   // enemy rotation = camera rotation (which is just where the player is facing)
        gameobjectThatLooksAtPlayer.transform.rotation = Quaternion.Euler(0f, gameobjectThatLooksAtPlayer.transform.rotation.eulerAngles.y, 0f); // prevents sprite from also turning of the x axis
        //print(Vector3.Distance(transform.position, player.position));

    }

    public void playerNotHurting(){

        
            playerColorOverlayAnimator.SetBool("isPlayerHurt", false); //called in "player overlay" script
            print("false");

    }
   
}
