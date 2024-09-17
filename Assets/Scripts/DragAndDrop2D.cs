using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop2D : MonoBehaviour {
    
    private Vector3 offset;
    private Camera cam;

    private void Start() {
        cam = Camera.main;
    }

    //Get the offset between the mouse position and the disk position
    void OnMouseDown() {
        offset = gameObject.transform.position - GetMouseWorldPos();
    }
    
    //Move the disk with the mouse while maintaining the offset
    void OnMouseDrag() {
        transform.position = GetMouseWorldPos() + offset;
    }

    //Convert mouse position to coordinate for mouse drag
    private Vector3 GetMouseWorldPos() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.nearClipPlane;
        return cam.ScreenToWorldPoint(mousePoint);
    }

    //Valid move logic
    void OnMouseUp() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("Tower")) {
            // Snap to the tower's position
            Vector3 snapPosition = hit.collider.transform.position;
        
            // Determine the stacking height for the disk based on other disks on the same tower
            float stackHeight = CalculateStackHeight(hit.collider.gameObject);
            snapPosition.y += stackHeight;  // Adjust Y position to stack the disk

            transform.position = snapPosition;
        }
    }

    float CalculateStackHeight(GameObject tower) {
        // Find all disks currently stacked on the tower and calculate their total height
        float height = 0f;
    
        // Iterate through all the children of the tower to find the highest disk
        foreach (Transform child in tower.transform) {
            if (child.CompareTag("Disk")) {  // Assuming disks are tagged as "Disk" 
                height += child.GetComponent<SpriteRenderer>().bounds.size.y;
            }
        }
        return height;
    }

}
