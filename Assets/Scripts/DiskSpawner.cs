using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSpawner : MonoBehaviour
{
    // List to hold the disk GameObjects in the correct order
    public List<GameObject> disks = new List<GameObject>();
    public int numOfDisks;

    // Time between activating each disk (in seconds)
    public float delay = 1.0f;

    private void Start() {
        //Check that spawner is working
        Debug.Log("Spawner Has Started");
        // Start the coroutine to activate disks
        StartCoroutine(ActivateDisks(numOfDisks));  // Start the coroutine here
    }

    // Coroutine to activate each disk with a delay
    private IEnumerator ActivateDisks(int numOfDisks) {
        yield return new WaitForSeconds(delay);
        Debug.Log("Entered Activation Phase");
        Debug.Log("Spawning " + numOfDisks + " disks");
        int num = numOfDisks;

        foreach (GameObject disk in disks) {
            
            if (disk != null && num > 0) {
                // Activate the current disk
                Debug.Log("Activating " + disk.name);
                disk.SetActive(true);
                num--;
                // Wait for the specified delay before activating the next disk
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
