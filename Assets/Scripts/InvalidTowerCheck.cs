using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidTowerCheck : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start() {
        Stack<float> towerStack = new Stack<float>();
    }

    //
    public void checkMove(size) {
        if (size > towerStack.Peek()) {
            Debug.Log("Invalid Move. You Lost");
        } else {
            addToTower(size);
        }

    } 

    public void addToTower(size) {
        towerStack.Push(size);
    }
}
