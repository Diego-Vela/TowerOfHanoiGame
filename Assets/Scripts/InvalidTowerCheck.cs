using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidTowerCheck : MonoBehaviour {
    private Stack<float> towerStack;

    // Start is called before the first frame update
    void Start() {
       towerStack = new Stack<float>();
    }

    //
    public bool checkMove(float size) {
        if (towerStack.Count > 0 && size > towerStack.Peek()) {
            Debug.Log("Invalid Move. You Lost");
            addToTower(size);
            //Add Lose menu panel
            return false;
        }
        addToTower(size);
        return true;
    } 

    public void addToTower(float size) {
        towerStack.Push(size);
    }

    public void removeFromTower() {
        towerStack.Pop();
    }
}