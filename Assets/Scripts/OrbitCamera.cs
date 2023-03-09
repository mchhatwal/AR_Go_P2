using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform playerAvatar; // The player character that the camera orbits around
    public float distance = 10.0f; // The distance between the camera and the player character
    public float sensitivity = 5.0f; // The sensitivity of the mouse when dragging to orbit the camera
    public Vector3 offset;
    private float x = 0.0f; // The current x rotation of the camera
    private float y = 0.0f; // The current y rotation of the camera

    void Start()
    {
        // Set the camera position and rotation to look at the player avatar
        Vector3 avatarPos = playerAvatar.position + offset;
        Vector3 groundPos = avatarPos - Vector3.up * 1.0f;
        //transform.position = groundPos + Vector3.up * distance;
        transform.position = groundPos + new Vector3(offset.x, 2.0f, offset.z);
        transform.rotation = Quaternion.LookRotation(groundPos - transform.position, Vector3.up);
    }

    void LateUpdate()
    {
        // Update the camera rotation based on mouse input
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * sensitivity;
            y -= Input.GetAxis("Mouse Y") * sensitivity;
        }

        // Clamp the y rotation to prevent the camera from flipping upside down
        y = Mathf.Clamp(y, 0, 90.0f);

        // Set the camera position and rotation to orbit around the player avatar
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + playerAvatar.position;
        transform.rotation = rotation;
        transform.position = position + Vector3.up * 1.0f;
    }
}