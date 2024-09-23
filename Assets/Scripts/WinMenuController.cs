using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
Script that manages the win menu when the game is won.
*/

public class WinMenuController : MonoBehaviour {
    public GameObject WinMenuPanel;

    // Start is called before the first frame update
    void Start() {
        WinMenuPanel.SetActive(false);
    }
    
    public void showMenu() {
        WinMenuPanel.SetActive(true);
    }

    //Function to reset the game
    public void restartGame() {
        SceneManager.LoadScene("GameplayScreen");
    }


    //Function to return to Title 
    public void returnToTitle() {
        Time.timeScale = 1f; //Resets the time scale
        SceneManager.LoadScene("TitleScreen");
    }
}
