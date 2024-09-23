using UnityEngine;

/*
Script that tracks collisions with the win tower 
*/
public class Disk : MonoBehaviour {
    private WinCondition winCondition;

    private void Start() {
        // Find the GameManager in the scene
        winCondition = FindObjectOfType<WinCondition>();
    }

    // Detect when the disk collides with the win tower using object name
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "TowerRight") {  // Compare the name of the object
            winCondition.DiskOnWinTower();
        }
    }

    // Detect when the disk leaves the win tower using object name
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "TowerRight") {  // Compare the name of the object
            winCondition.DiskOffWinTower();
        }
    }
}
