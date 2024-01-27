using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    [Range(0f, 90f)]
    public float yLimit = 85f;

    public float sensitivity = .8f;

    private Vector2 rotation;

    public void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Adapted from https://gist.github.com/KarlRamstedt/407d50725c7b6abeaf43aee802fdd88e
    public Quaternion UpdateCameraRotation(Vector2 input)
    {
        rotation.x += input.x * sensitivity;
        rotation.y += input.y * sensitivity;
        //Prevent vertical roation from flipping
        rotation.y = Mathf.Clamp(rotation.y, -yLimit, yLimit);

        Quaternion xPlayerRotation = Quaternion.AngleAxis(rotation.x, Vector3.up);
        Quaternion yCamRotation = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = yCamRotation;

        // return x axis rotation to main player object
        return xPlayerRotation;
    }
}
