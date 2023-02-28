using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] public Transform orientation;
    public Vector3 runDirection;
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
        runDirection = Quaternion.Euler(0, orientation.eulerAngles.y, 0) * runDirection;
        }
    }
    // Update 1is called once per frame
    void Update()
    {
        rbody.velocity = runDirection * runSpeed;
    }
}
