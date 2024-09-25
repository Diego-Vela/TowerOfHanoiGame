using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Script that manages the Title Screen
*/

public class NewBehaviourScript : MonoBehaviour
{
   public void PlayGame()
   {
        SceneManager.LoadScene("GameplayScreen");//Load scene bty name "___" or index
   }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   public void QuitGame()
   {
        Application.Quit();
        //Code for using unity editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
   }
}
