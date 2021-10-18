using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItems : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    Player playerScript;
    Transform playerTransform;
    private float minItemPickupDistance = 3f;
    Vector3 gameobjectToPlayerVector;

    //items:
    Handgun shootScript;
    string itemTag;


    void Awake()
    {
        cam = Camera.main;
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        shootScript = GameObject.Find("Gun").GetComponent<Handgun>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        itemTag = gameObject.tag;

    }



    void Update()
    {   
        //2D ROTATION

        playerScript.makeGameobjectLookAtPlayer(gameObject, cam, gameobjectToPlayerVector);


        //Pick up AMMO

        if(Vector3.Distance(transform.position, playerTransform.position) <= minItemPickupDistance){

            if(shootScript.ammo < shootScript.maxAmmo){
                
                switch(itemTag){

                    case "ammoSingle":
                        shootScript.ammo += 1;
                        shootScript.updateAmmoTextbox();
                        break;
                    
                    case "ammoBox":
                        shootScript.ammo += 5;
                        if(shootScript.ammo > shootScript.maxAmmo){
                            shootScript.ammo = shootScript.maxAmmo;
                        }
                        shootScript.updateAmmoTextbox();
                        break;
                    
                    default:
                        print("Spelling error with tags in script \"CollectibleItems\".");
                        break;

                }
            
                Destroy(gameObject);
            }



        }





        
    }
}
