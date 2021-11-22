using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementController : MonoBehaviour
{
    [SerializeField] private Vector3 defaultRotation;
    [SerializeField] private float horizontalRotationSensitivity = 1.0f;
    [SerializeField] private float verticalRotationSensitivity = 1.0f;
    [SerializeField] private float resetRate = 100f;
    
    
    void Start() // Default rotation set to the rotation of the Rubik's Cube on compilation
    {
        defaultRotation = this.gameObject.transform.rotation.eulerAngles;
    }

    void Update() // Handles Mouse Movement Each Frame
    {
        if (Input.GetMouseButton(0))
        {
            float xRotation = -Time.deltaTime * verticalRotationSensitivity * Input.GetAxis("Mouse X");
            float yRotation = -Time.deltaTime * horizontalRotationSensitivity * Input.GetAxis("Mouse Y");

            this.transform.Rotate(new Vector3(yRotation, xRotation, 0), Space.World);
        }
        else
        {
            Quaternion cR = this.transform.rotation; // Current Quaternion Rotation
            if ((Mathf.Abs(defaultRotation.magnitude - cR.eulerAngles.magnitude) >= 1f))
                this.transform.Rotate(new Vector3((defaultRotation.x - cR.x) * resetRate * Time.deltaTime, (defaultRotation.y - cR.y) * resetRate * Time.deltaTime, (defaultRotation.z - cR.z) * resetRate * Time.deltaTime));

        }
      
    }
}
