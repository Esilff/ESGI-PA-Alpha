using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private  Transform target;
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
    
    // Update is called once per frame
    private void LateUpdate()
    {
        camera.position = target.position + (target.forward * offset.z) + Vector3.up * offset.y;
        camera.LookAt(target, target.up);
    }
}
