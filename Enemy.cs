using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    private Camera cam;
    Transform player;
    public Animator enemyAnimator;


    float minEnemyFollowDist = 5f;
    float maxEnemyFollowDist = 20f;
    float enemyMoveSpeed = 10f;
    public int enemyHealth = 100;


    public int playerAttackStrength = 25;
    Vector3 enemyToPlayerVector;



    void Start(){

        cam = Camera.main;
        player = GameObject.Find("Player").GetComponent<Transform>();

        //enemyAnimator.Rebind();
        //player = GameObject.Find("Player").GetComponent<Transform>();
    }



    void LateUpdate(){   

        //ENEMY 2D ROTATION

        enemyToPlayerVector = (transform.position - cam.transform.position).normalized; 
        transform.rotation = Quaternion.LookRotation(enemyToPlayerVector, Vector3.up);   //enemy rotation = line made from enemy to player
        //transform.rotation = cam.transform.rotation;                                   // enemy rotation = camera rotation (which is just where the player is facing)
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f); // prevents sprite from also turning of the x axis
        //print(Vector3.Distance(transform.position, player.position));


        //ENEMY AI

        if(Vector3.Distance(transform.position, player.position) >= minEnemyFollowDist && Vector3.Distance(transform.position, player.position) <= maxEnemyFollowDist && enemyAnimator.GetBool("isEnemyHurting") == false){ 
            
            // if greater than min but less than max
            // in this case: 5 <= d <= 20
            // if also not hurting
            transform.position -= transform.forward * enemyMoveSpeed * Time.deltaTime;   // enemy follows player
            //print("postition: " + transform.position);
            // print("forward: " + transform.forward);
            // print("speed: " + enemyMoveSpeed);
            // print("deltaT: " + Time.deltaTime);
            enemyAnimator.SetBool("isPlayerFollowable", true);                //signals for enemy walking animation to begin



            if(Vector3.Distance(transform.position, player.position) <= minEnemyFollowDist){ //if enemy gets to or closer than minimum follow distance
                
                enemyAnimator.SetBool("isEnemyAttacking", true);                        //variable accessed by player script to adjust player info accordingly
                //that means enemy is attacking

                } else {

                enemyAnimator.SetBool("isEnemyAttacking", false);
                //if father away, then enemy is NOT attacking
                }


        } else {

            enemyAnimator.SetBool("isPlayerFollowable", false);                         // if out of that margin, signals for enemy walking animation to end and for idle animation to begin
        }
        
    }




    public void enemyNoHurting(){                                                      //signals the end of the hurting animation. Other animations only execute AFTER "isEnemyHurting" is FALSE

        enemyAnimator.SetBool("isEnemyHurting", false);  

        print("not hurting");

    }


    public void enemyHealthDecrease(){

        enemyHealth -= playerAttackStrength;
        //print("-" + playerAttackStrength);

            if(enemyHealth <= 0){

                //print("dead");
                Destroy(gameObject);

            }
    }

    public void whenPlayerAttacked(){

        GameObject.Find("Player").GetComponent<Player>().playerHurtFromAttack();
    }



}
