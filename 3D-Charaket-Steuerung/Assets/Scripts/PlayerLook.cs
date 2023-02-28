using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float lookAcceleration;

    private Vector3 angle;
    private Vector3 lerpAngle;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // MouseInput
        angle.x -= context.ReadValue<Vector2>().y * sensitivity;
        angle.y += context.ReadValue<Vector2>().x * sensitivity;

        // Rotation handling
        angle.x = Mathf.Clamp(angle.x, -90f, 90f);

        lerpAngle = Vector3.Lerp(lerpAngle, angle, lookAcceleration * Time.deltaTime);
        // Rotation and Orientation
        transform.eulerAngles = lerpAngle;

    }
    // Update is called once per frame
    void Update()
    {
    }
}
