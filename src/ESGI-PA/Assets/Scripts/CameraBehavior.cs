using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private static Transform target;
    [SerializeField] private Transform camera;

    [SerializeField] private Vector3 offset;

    [SerializeField] private float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        camera.position = target.position + offset;
        camera.LookAt(target);
        camera.rotation = Quaternion.Slerp(camera.rotation, target.rotation, cameraSpeed);
    }

    private void FixedUpdate()
    {
        //if (Physics.Raycast(camera.position, -camera.up, 2f)) offset.y = 1;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        camera.position = target.position + (target.forward * offset.z) + Vector3.up * offset.y;
        camera.LookAt(target, target.up);
    }

    public static void setTarget(Transform obj)
    {
        target = obj;
    }
    // transform.position = target.position;
    //     
    // Vector2 look = input.actions["Look"].ReadValue<Vector2>();
    //     
    // transform.Rotate(Vector3.up, look.x * sensi * Time.deltaTime);
    //
    // rotX -= look.y * sensi * Time.deltaTime;
    //
    // if (rotX > maxX) rotX = maxX;
    // else if (rotX < -maxX) rotX = -maxX;
    //     
    // rotatorX.localRotation = Quaternion.Euler(rotX, 0, 0);
}
