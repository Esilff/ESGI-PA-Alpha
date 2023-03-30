using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // --- Components ---
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Character _character;

    [SerializeField] private Rigidbody rb;
    
    // --- Controls ---

    private Vector2 movement = Vector2.zero; //y for acceleration, x for turning
    private bool doSpecialAction = false;
    private bool isTriggeringBonus = false;

    // --- Delegates ---

    private Action<Rigidbody, Vector2> behave;
    // --- Next ---
    
    void Start()
    {
        CameraBehavior.setTarget(transform);
        behave = _character.behave;
    }

    // Update is called once per frame
    void Update()
    {
        movement = _input.actions["Movement"].ReadValue<Vector2>();
        doSpecialAction = _input.actions["Drift"].IsPressed();
        isTriggeringBonus = _input.actions["Bonus"].IsPressed();
    }

    private void FixedUpdate()
    {
        behave(rb, movement);

    }
}
