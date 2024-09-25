using UnityEngine;

/*
Script that tracks the win condition of the game for Tower of Hanoi Game
*/
public class WinCondition : MonoBehaviour
{
    public GameObject winTower; // Reference to the winning tower
    private int totalDisks; // Number of disks in the game
    private int disksOnTower; // Counter for disks on the win tower
    private WinMenuController winMenu; // Controller for win menu panel

    private void Start() {
        // Initialize the number of disks
        disksOnTower = 0;
        //Get reference to WinMenuController
        winMenu = FindObjectOfType<WinMenuController>();
    }

    public void setTotalDisks(int num) {
        totalDisks = num;
    }

    // Tracks when a new disk enters the win tower
    public void DiskOnWinTower() {
        disksOnTower++;
        Debug.Log(disksOnTower + "/" + totalDisks);
        CheckWinCondition();
    }

    // Tracks when a disk leaves the win tower
    public void DiskOffWinTower() {
        disksOnTower--;
    }

    // Check if the player has won by stacking all disks on the win tower
    public void CheckWinCondition() {
        if (disksOnTower == totalDisks) { //Needs to add a valid move before disks on tower
            WinGame();
        }
    }

    // Handle win condition (e.g., display a message or transition to another scene)
    void WinGame() {
        Debug.Log("All disks are on the win tower! You win the game!");
        Debug.Log("Total Disks:" + totalDisks);
        winMenu.showMenu();
    }
}
