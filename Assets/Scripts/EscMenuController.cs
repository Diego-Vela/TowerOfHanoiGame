using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
Script that manages the escape menu of the game
*/

public class EscapeMenuController : MonoBehaviour {
    public GameObject EscMenuPanel;
    private bool isPaused = false;

    // Start is called before the first frame update
    private void Start() {}

    // Update is called once per frame
    void Update() {
        //Check for escape key press
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //if the escape menu is already open, close it.
            if(isPaused) {
                resume();
            } 
            //Pause the game otherwise
            else {
                pause();
            }
        }
    }
    
    //Function connected to Resume button
    public void resume() {
        EscMenuPanel.SetActive(false);
        Time.timeScale = 1f; // Resumes 1 frame
        isPaused = false;
    }
    
    //Function that pauses the game
    void pause() {
        EscMenuPanel.SetActive(true);
        Time.timeScale = 0f; // Pauses 0 frames
        isPaused = true;
    }

    //Function to return to Title 
    public void returnToTitle() {
        Time.timeScale = 1f; //Resets the time scale
        SceneManager.LoadScene("TitleScreen");
    }
}
