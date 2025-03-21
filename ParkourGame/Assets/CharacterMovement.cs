using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float turnSpeed = 10f; // Speed of turning
    public float jumpspeed = 10f;
    public Rigidbody rb;
    public Animator animator; // Animator for movement animations
    public Camera playerCamera; // Camera to determine direction
    public AudioSource audio;

    void Start() {
        //audio = GetComponent<AudioSource>();
        audio.Play();
        rb = GetComponent<Rigidbody>();
        //Debug.Log(audio);
    }

    void Update()
    {
        // Get input from the user (WASD or arrow keys)
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down
     //   float moveY = Input.GetKeyDown("Spacebar"); // Spacebar


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
            audio.Stop();
            Debug.Log("Stop alles");
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
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 5, 0);
        }
    }

void checkAudio()
    {
        if(!audio.isPlaying){
            audio.Play();
        }
    }
}
