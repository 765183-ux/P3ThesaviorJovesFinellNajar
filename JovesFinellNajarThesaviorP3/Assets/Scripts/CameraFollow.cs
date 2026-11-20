using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    [Header("Target Settings")]
    public Transform target;          // Drag your Player object here in the Inspector
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Keeps camera at Z = -10

    [Header("Smoothness")]
    public float smoothTime = 0.25f;  // Lower = snappier, Higher = looser/smoother

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Exit if no player is assigned to avoid errors
        if (target == null) return;

        // Calculate the desired position based on the player's position + offset
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera toward that position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}