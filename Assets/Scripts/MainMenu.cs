using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        UnityEditor.EditorApplication.isPlaying = false;
   }
    
}
