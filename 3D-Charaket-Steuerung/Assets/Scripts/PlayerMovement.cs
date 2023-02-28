using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField]
    private Vector3 runDirection;
    private Rigidbody rbody;
    void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }
    public void Walking(InputAction.CallbackContext context)
    {
        runDirection = context.ReadValue<Vector3>();
        if (context.performed)
        {
            rbody.velocity = runDirection * runSpeed;
        }
    }
    // Update 1is called once per frame
    void Update()
    {
    }
}
