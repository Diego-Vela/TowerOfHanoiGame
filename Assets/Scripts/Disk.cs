using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script that tracks collisions with the win tower 
*/
public class Disk : MonoBehaviour {
    private WinCondition winCondition;
    private InvalidTowerCheck towerLeft;
    private InvalidTowerCheck towerMid;
    private InvalidTowerCheck towerRight;
    private float size; // Holds the size of the disk.
    // Reference to the DragAndDrop2D script
    private DragAndDrop2D DaD;

    private void Start() {
        // Get the size of the disk that was created
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        size = spriteRenderer.sprite.bounds.size.x * transform.localScale.x;

        // Debug statement
        Debug.Log(gameObject.name + " size: " + size);

        // Find the WinCondition object in the scene
        winCondition = FindObjectOfType<WinCondition>();

        // Find the towers in the scene (assuming they are named "TowerLeft", "TowerMid", "TowerRight")
        towerLeft = GameObject.Find("TowerLeft").GetComponent<InvalidTowerCheck>();
        towerMid = GameObject.Find("TowerMid").GetComponent<InvalidTowerCheck>();
        towerRight = GameObject.Find("TowerRight").GetComponent<InvalidTowerCheck>();

        // Get the component for Drag&Drop
        DaD = GetComponent<DragAndDrop2D>();
    }

    // Detect when the disk collides with the win tower using object name
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "TowerRight") {
            Debug.Log("Adding " + size + " to right tower stack");
            towerRight.checkMove(size);
            winCondition.DiskOnWinTower();            
        }
        else if (other.gameObject.name == "TowerMid") {
            Debug.Log("Adding " + size + " to mid tower stack");
            towerMid.checkMove(size);
        }
        else if (other.gameObject.name == "TowerLeft") {
            Debug.Log("Adding " + size + " to left tower stack");
            towerLeft.checkMove(size);
        }
    }

    // Detect when the disk leaves the win tower using object name
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "TowerRight") {
            Debug.Log("Removing " + size + " from right tower stack");
            towerRight.removeFromTower();
            winCondition.DiskOffWinTower();
        }
        else if (other.gameObject.name == "TowerMid") {
            Debug.Log("Removing " + size + " from mid tower stack");
            towerMid.removeFromTower();
        }
        else if (other.gameObject.name == "TowerLeft") {
            Debug.Log("Removing " + size + " from left tower stack");
            towerLeft.removeFromTower();
        }
    }
}
