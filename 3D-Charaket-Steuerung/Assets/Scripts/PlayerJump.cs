using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool grounded;
    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    bool GroundCheck()
    {
        float extendedHeight = 1.1f;
        return Physics.Raycast(transform.position, Vector3.down, extendedHeight);

    }

    public void Jumping(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("jump");
        }
    }
    // Update is called once per frame
    void Update()
    {
        grounded = GroundCheck();
    }
}
