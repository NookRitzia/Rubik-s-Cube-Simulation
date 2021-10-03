using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementController : MonoBehaviour
{
    [SerializeField] private Vector3 defaultRotation;
    //private GameObject cubeAttached;
    [SerializeField] private float horizontalRotationSensitivity = 1.0f;
    [SerializeField] private float verticalRotationSensitivity = 1.0f;
    [SerializeField] private float resetRate = 100f;

    
   // [SerializeField] private float xRotation = 0f;
   // [SerializeField] private float yRotation = 0f;
    void Start()
    {
        defaultRotation = this.gameObject.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
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
