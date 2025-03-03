using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookY : MonoBehaviour
{
    public float sensitivity = 2.0f; // Mouse sensitivity
    public float minY = -45f; // Minimum vertical angle
    public float maxY = 45f;  // Maximum vertical angle

    private float rotationY = 0f;

    void Update()
    {
        // Get mouse input
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Adjust vertical rotation
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        // Apply rotation
        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
    }
}
