using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script that manages Drag and Drop of Disks
This script was ChatGPT generated using my own DragAndDropMethod to prevent the disks from
dragging through the towers.
*/

[RequireComponent(typeof(Rigidbody2D))]
public class DragAndDrop2D : MonoBehaviour {

    private Vector3 offset;
    public bool isDragging = false;
    private Vector3 originalPos;
    private Camera cam;
    private Rigidbody2D rb;
    private Collider2D objectCollider;

    // Variables to control axis locking
    private bool lockHorizontal = false;
    private bool lockVertical = false;

    public float moveSpeed = 10f; // Adjust the speed as needed
    public LayerMask collisionLayers; // Layers that should block the movement

    private void Start() {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<Collider2D>();

        // Ensure Rigidbody is dynamic and uses continuous collision detection
        rb.isKinematic = false;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // Get the offset between the mouse position and the disk position
    void OnMouseDown() {
        offset = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 0;

        originalPos = transform.position;
        isDragging = true;

        // Optionally freeze rotation if needed
        rb.freezeRotation = true;
    }

    // Move the disk with the mouse while maintaining the offset
    void OnMouseDrag() {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Calculate the target position
        Vector3 targetPos = mousePosition + offset;

        // Separate the target positions into X and Y
        Vector3 newPosition = transform.position;

        // Check for horizontal and vertical collisions
        CheckCollisions();

        // If horizontal movement is not locked, move on the X axis
        if (!lockHorizontal) {
            newPosition.x = targetPos.x;
        }

        // If vertical movement is not locked, move on the Y axis
        if (!lockVertical) {
            newPosition.y = targetPos.y;
        }

        // Use Rigidbody's MovePosition to move the object while respecting physics
        rb.MovePosition(newPosition);
    }

    // Check for collisions on each axis separately
    void CheckCollisions() {
        // Define bounds for collision checking (size of the object)
        Bounds bounds = objectCollider.bounds;

        // Horizontal collision check
        Vector2 leftCheck = new Vector2(bounds.min.x - 0.05f, transform.position.y);
        Vector2 rightCheck = new Vector2(bounds.max.x + 0.05f, transform.position.y);
        bool hitLeft = Physics2D.OverlapPoint(leftCheck, collisionLayers);
        bool hitRight = Physics2D.OverlapPoint(rightCheck, collisionLayers);

        // If there's a collision on either side, lock horizontal movement
        lockHorizontal = hitLeft || hitRight;

        // Vertical collision check
        Vector2 topCheck = new Vector2(transform.position.x, bounds.max.y + 0.05f);
        Vector2 bottomCheck = new Vector2(transform.position.x, bounds.min.y - 0.05f);
        bool hitTop = Physics2D.OverlapPoint(topCheck, collisionLayers);
        bool hitBottom = Physics2D.OverlapPoint(bottomCheck, collisionLayers);

        // If there's a collision on either top or bottom, lock vertical movement
        lockVertical = hitTop || hitBottom;
    }

    void OnMouseUp() {
        isDragging = false;

        // Reset velocity to stop movement when drag ends
        rb.velocity = Vector2.zero;

        // Optionally unfreeze rotation
        rb.freezeRotation = false;
    }

    // Gets Variable to isDragging
    public bool IsDragging {
        get { return isDragging; }
    }
}
