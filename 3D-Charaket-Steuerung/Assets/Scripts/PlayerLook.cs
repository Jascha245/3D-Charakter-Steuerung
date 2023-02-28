using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [SerializeField] private Transform orientationalTransform;

    private float xRotation;
    private float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }
    public void OnLook(InputAction.CallbackContext context)
    {

    }

    // Update is called once per frame
    void Update()
    {
        // MouseInput
        float xAngle = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float yAngle = Input.GetAxisRaw("Mouse X") * Time.deltaTime * ySensitivity;

        // Rotation handling
        yRotation += xAngle;
        xRotation += yAngle;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotation and Orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientationalTransform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
