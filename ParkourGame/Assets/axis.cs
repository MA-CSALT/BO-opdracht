using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookX : MonoBehaviour
{
    public float sensitivity = 2.0f; // Mouse sensitivity

    private float rotationX = 0f;

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // Adjust horizontal rotation
        rotationX += mouseX;

        // Apply rotation
        transform.localRotation = Quaternion.Euler(0f, rotationX, 0f);
    }
}
