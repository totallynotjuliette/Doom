using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Button tryAgainButton;
    public GameObject gameOverMenu;

    void Start()
    {   
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tryAgainButtonClicked(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1; //pauses game (time not running)
        Cursor.lockState = CursorLockMode.Locked;



    }

}
