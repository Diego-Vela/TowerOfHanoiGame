using UnityEngine;

/*
Script that tracks collisions with the win tower 
*/
public class Disk : MonoBehaviour {
    private WinCondition winCondition;
    private InvalidTowerCheck checkMove;
    private float size; //Holds the size of the disk.

    private void Start() {
        //Get the size of disk that was created
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        size = spriteRenderer.sprite.bounds.size.x * transform.localScale.x;
        //Check statement
        Debug.Log(gameObject.name + " size: " + size);
        // Find the WinCondition in the scene
        winCondition = FindObjectOfType<WinCondition>();
        // Check the Tower in the scene
        checkMove = FindObjectOfType<InvalidTowerCheck>();
    }

    // Detect when the disk collides with the win tower using object name
    private void OnTriggerEnter2D(Collider2D other) {
        //Logic to check tower stack and win conditions.
        if (other.gameObject.name == "TowerRight") {  // Compare the name of the object
            checkMove.addToTower(size);
            winCondition.DiskOnWinTower();
        }
        else if (other.gameObject.name == "TowerMid") {
            checkMove.addToTower(size);
        }
        else {
            checkMove.addToTower(size);
        }

    }

    // Detect when the disk leaves the win tower using object name
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "TowerRight") {  // Compare the name of the object
            winCondition.DiskOffWinTower();
        }
    }
}
