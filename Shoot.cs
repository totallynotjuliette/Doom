using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator gunAnimator;
    //public Animator enemyAnimator;
    //public SpriteRenderer enemy;

    Ray ray;
    RaycastHit rayHit;
    public int shootingDistance = 1200;




    void Update()
    {

        if(Input.GetMouseButtonDown(0)) //when click, gun is "shot"
        {
            gunAnimator.SetBool("isPlayerClickingToShoot", true);
            //print("click");



        } else if(Input.GetMouseButtonUp(0)) { //when click, gun is reset to "unshot"

            gunAnimator.SetBool("isPlayerClickingToShoot", false);
        }
    }


    public void gunAnimationStarted(){ //when animation starts... aka when got is shot...

        gunAnimator.SetBool("isPlayerGunAnimationRunning", true);   //code is notified that the gun animation is running

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //ray is set up so that it is where mouse is pointing


            if(Physics.Raycast(ray, out rayHit, shootingDistance) && (rayHit.collider.tag == "enemy")){ 
                //if enemy is shot and not hurting already.

                GameObject.Find(rayHit.collider.name).GetComponent<Animator>().SetBool("isEnemyHurting", true);

                //GameObject.Find(rayHit.collider.name).GetComponent<Animator>().SetBool("isEnemyAttacking", false);
                //enemyAnimator.SetBool("isEnemyHurting", true);   //enemy is "hurt"
                print("hurting");

            }

    }



    public void gunAnimationEnded(){

        gunAnimator.SetBool("isPlayerGunAnimationRunning", false);  // when animation ends, code is notified that animation has ended
        // this guarantees that the gun animation finishes and isnt cut midway through by another action

        //
    }

    
}
