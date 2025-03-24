using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody rb;
    public Animator animator;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(0, 5, 0);
            animator.SetBool("Jump", true); // Start jump animation
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        animator.SetBool("Jump", false); // Stop jump animation when landing
    }
}
