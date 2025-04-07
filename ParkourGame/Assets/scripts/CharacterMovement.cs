using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Movement speed
    public float turnSpeed = 8f; // Speed of turning
    public Animator animator; // Animator for movement animations
    public Camera playerCamera; // Camera to determine direction
    public AudioSource audio;

    private float cameraPitch = 0f; // Camera pitch angle

    void Start()
    {
        audio.Play();
    }

    void Update()
    {
        // === MOUSE LOOK ===
        float mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * turnSpeed;

        // Rotate character left/right (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera up/down (pitch)
        cameraPitch -= mouseY; // Invert to feel natural
        cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f); // Clamp to avoid flipping
        playerCamera.transform.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);

        // === MOVEMENT ===

        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        move.Normalize();

        // Reset all animations before applying new movement
        animator.SetBool("WalkForwards", false);
        animator.SetBool("WalkBackwards", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkRight", false);

        if (move.magnitude < 0.1f)
        {
            audio.Stop();
            Debug.Log("Stop alles");
            return; // ✅ Now it's fine! Mouse look already happened.
        }

        transform.position += move * moveSpeed * Time.deltaTime;

        // Apply movement animations based on input
        if (moveZ > 0.1f) // Walk Forward
        {
            checkAudio();
            animator.SetBool("WalkForwards", true);
            Debug.Log("play forward audios");
        }
        else if (moveZ < -0.1f) // Walk Backward
        {
            checkAudio();
            animator.SetBool("WalkBackwards", true);
            Debug.Log("play back audios");
        }
        else if (moveX < -0.1f) // Walk Left
        {
            checkAudio();
            animator.SetBool("WalkLeft", true);
            Debug.Log("play left audios");
        }
        else if (moveX > 0.1f) // Walk Right
        {
            checkAudio();
            animator.SetBool("WalkRight", true);
            Debug.Log("play right audios");
        }
    }

    void checkAudio()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}