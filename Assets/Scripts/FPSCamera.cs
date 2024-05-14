// Camera movement based on tutorial by Unity Ace: https://www.youtube.com/watch?v=5Rq8A4H6Nzw
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    public float mouseSens = 2f;
    float cameraHRot = 0f;
    float cameraVRot = 0f;
    
    bool lockedCursor = true;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
 

    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSens;
        float inputY = Input.GetAxis("Mouse Y") * mouseSens;

        cameraVRot -= inputY;
        cameraVRot = Mathf.Clamp(cameraVRot, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVRot;

        cameraHRot += inputX;
        cameraHRot = Mathf.Clamp(cameraHRot, -45f, 45f);
        transform.localEulerAngles += Vector3.up * cameraHRot;

    }
}
