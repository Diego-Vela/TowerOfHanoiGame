using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop2D : MonoBehaviour {
    
    private Vector3 offset;
    private bool isDragging = false;
    private Vector3 originalPos;
    private Camera cam;

    private void Start() {
        cam = Camera.main;
    }

    //Get the offset between the mouse position and the disk position
void OnMouseDown() {
    // Record the offset between the disk and the mouse click point
    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    offset.z = 0;
        
    // Set original position in case we need to reset it
    originalPos = transform.position;
        
    isDragging = true;
}
    
    //Move the disk with the mouse while maintaining the offset
    void OnMouseDrag() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition + offset; // Add the offset to the mouse position
        
        // Check for tower collision
        if (IsCollidingWithTower()) {
            // Reset position to original to prevent passing through the tower
            transform.position = originalPos;
        }
        else {
            // Update originalPosition to current when there's no collision
            originalPos = transform.position;
        }
    }

    /*Convert mouse position to coordinate for mouse drag NOT NEEDED ANYMORE
    private Vector3 GetMouseWorldPos() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.nearClipPlane;
        return cam.ScreenToWorldPoint(mousePoint);
    } */

    void OnMouseUp() {
        isDragging = false;
    }
    
    bool IsCollidingWithTower() {
    Collider2D towerCollider = Physics2D.OverlapPoint(transform.position);

    if (towerCollider != null && towerCollider.CompareTag("Tower")) {
        return true;
    }

    return false;
}

}
