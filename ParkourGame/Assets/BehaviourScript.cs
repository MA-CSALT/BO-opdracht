using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float turnSpeed = 10f; // Speed of turning
    public Animator animator; // Animator for movement animations
    public Camera playerCamera; // Camera to determine direction

    void Update()
    {
        // Get input from the user (WASD or arrow keys)
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Create a movement vector relative to character's facing direction
        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        move.Normalize();

        // If there is no movement, stop early
        if (move.magnitude < 0.1f)
        {
            animator.SetBool("WalkForwards", false);
            animator.SetBool("WalkBackwards", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
            return;
        }

        // Move the character
        transform.position += move * moveSpeed * Time.deltaTime;

        // Rotate character based on mouse movement (Y-axis only)
        float mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        transform.Rotate(Vector3.up * mouseX);

        // Reset all animations before applying new movement
        animator.SetBool("WalkForwards", false);
        animator.SetBool("WalkBackwards", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkRight", false);

        // Apply movement animations based on input
        if (moveZ > 0.1f) // Walk Forward
        {
            animator.SetBool("WalkForwards", true);
        }
        else if (moveZ < -0.1f) // Walk Backward
        {
            animator.SetBool("WalkBackwards", true);
        }
        else if (moveX < -0.1f) // Walk Left
        {
            animator.SetBool("WalkLeft", true);
        }
        else if (moveX > 0.1f) // Walk Right
        {
            animator.SetBool("WalkRight", true);
        }
    }
}
