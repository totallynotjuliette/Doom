using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWorld : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemyPrefab;
    GameObject clone;
     Vector3 randomPos;


    void Start()
    {   
            // for(int x = 1; x <= 3; x++){

            //     print("new");

            // randomPos = new Vector3(Random.Range(75, 125), 2.2f, Random.Range(75, 125));

            // clone = Instantiate(enemyPrefab, new Vector3(100f, 2.2f, 100f), Quaternion.Euler(0f, 0f, 0f));

            // //lone.transform.parent = gameObject.transform;
            // clone.transform.position = randomPos;

            // }

            for(int x = 1; x <= 3; x++){

                clone = Instantiate(enemyPrefab, new Vector3(100f, 2.2f, 100f), Quaternion.Euler(0f, 0f, 0f));


            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// Ryan was here :), wait where is he driving that car to? RYAN WATCH OUT THERES A WALL