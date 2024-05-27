// Camera movement based on tutorial by Unity Ace: https://www.youtube.com/watch?v=5Rq8A4H6Nzw
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    public float mouseSens = 2f;
    float cameraHRot = 0f;
    float cameraVRot = 0f;
    private Camera fpsCam;
    private bool followMouse = true;

    public bool FollowMouse{
        get {return followMouse; }
        set {
            followMouse = value;
            if (followMouse){
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }


    void Start()
    {
        fpsCam = GetComponent<Camera>();
        followMouse = true;
    }
 

    void Update()
    {
        // move camera around if followmouse is active
        if (followMouse){
            float inputX = Input.GetAxis("Mouse X") * mouseSens;
            float inputY = Input.GetAxis("Mouse Y") * mouseSens;

            cameraVRot -= inputY;
            cameraVRot = Mathf.Clamp(cameraVRot, -90f, 90f);
            transform.localEulerAngles = Vector3.right * cameraVRot;

            cameraHRot += inputX;
            cameraHRot = Mathf.Clamp(cameraHRot, -45f, 45f);
            transform.localEulerAngles += Vector3.up * cameraHRot;

            //recieve shooting input
            if (Input.GetButtonDown("Fire1")){
                Shoot();
            }
        }
    }


    void Shoot(){
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, transform.forward, out hit, 1000f)){
            
            // handle the collision
            TargetPrefab hitTarget = hit.collider.GetComponent<TargetPrefab>();

            if (hitTarget != null){
                hitTarget.Damage();
            }
        }
    }
}
