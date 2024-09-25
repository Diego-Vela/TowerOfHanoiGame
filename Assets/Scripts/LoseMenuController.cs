using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
Script that manages the win menu when the game is won.
*/

public class LoseMenuController : MonoBehaviour {
    public GameObject LoseMenuPanel;

    // Start is called before the first frame update
    private void Start() {
        LoseMenuPanel.SetActive(false);
    }
    
    public void showMenu() {
        LoseMenuPanel.SetActive(true);
    }

    //Function to reset the game
    public void restartGame() {
        SceneManager.LoadScene("GameplayScreen");
    }


    //Function to return to Title 
    public void returnToTitle() {
        SceneManager.LoadScene("TitleScreen");
    }
}
