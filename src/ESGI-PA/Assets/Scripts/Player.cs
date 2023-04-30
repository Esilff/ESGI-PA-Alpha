using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerStats stats;
    
    private bool _isIAControlled = false;

    public bool IsIAControlled
    {
        get => _isIAControlled;
        set
        {
            _isIAControlled = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // input.actions["Jump"].started += jump();
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        controller.Move(new Vector3(0, -0.1f, 0));
    }
}
