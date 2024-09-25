using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCanvas : MonoBehaviour{
    public GameObject SetUpPanel;
    private DiskSpawner spawner;
    private 

    // Start is called before the first frame update
    void Start() {
        SetUpPanel.SetActive(true);
        spawner = GameObject.Find("RingContainer").GetComponent<DiskSpawner>();
    }

    public void SpawnDisk(int num) {
        SetUpPanel.SetActive(false);
        spawner.StartSpawn(num);
    }
}
