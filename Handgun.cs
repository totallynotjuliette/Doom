using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Handgun : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator gunAnimator;
    //public Animator enemyAnimator;
    //public SpriteRenderer enemy;

    Ray ray;
    RaycastHit rayHit;
    public int shootingDistance = 1200;

    public int ammo = 0;
    public int maxAmmo = 15;

    public GameObject gameOverCanvas;

    public TMP_Text ammoNumberText;


    void Start(){
        ammo = maxAmmo;
        updateAmmoTextbox();
    }

    void Update()
    {

        if( Input.GetMouseButtonDown(0) && (!gameOverCanvas.activeInHierarchy) && (ammo != 0) && (gunAnimator.GetBool("isPlayerGunAnimationRunning") == false) ){
        //when player clicks, no canvas open, and player still has ammo, gun is considered shot
            gunAnimator.SetBool("isPlayerClickingToShoot", true); 
            // animator is dependent on this var. If true, gun animation starts.
            ammo--;
            updateAmmoTextbox();

        } else {

            gunAnimator.SetBool("isPlayerClickingToShoot", false);
        }

    }




    public void gunAnimationStarted(){ 
    //when animation starts... aka when got is shot... (this is run by an animation event)

        gunAnimator.SetBool("isPlayerGunAnimationRunning", true);   
        //code is notified that the gun animation is running

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        //ray is set up so that it is where mouse is pointing

        


            if(Physics.Raycast(ray, out rayHit, shootingDistance) && (rayHit.collider.tag == "enemy") && GameObject.Find(rayHit.collider.name).GetComponent<Animator>().GetBool("isEnemyHurting") == false){ 
                //if enemy is shot and not hurting already.
            
                GameObject.Find(rayHit.collider.name).GetComponent<Animator>().SetBool("isEnemyHurting", true);
                GameObject.Find(rayHit.collider.name).GetComponent<Animator>().SetBool("isEnemyAttacking", false);
                print("hurting");

            } else {
                
                GameObject.Find(rayHit.collider.name).GetComponent<Animator>().SetBool("isEnemyHurting", false);
            }

    }



    public void gunAnimationEnded(){

        gunAnimator.SetBool("isPlayerGunAnimationRunning", false);  
        // when animation ends, code is notified that animation has ended
        // this guarantees that the gun animation finishes and isnt cut midway through by another action
    }



    public void updateAmmoTextbox(){

        ammoNumberText.SetText(ammo.ToString());

    }

    
}
