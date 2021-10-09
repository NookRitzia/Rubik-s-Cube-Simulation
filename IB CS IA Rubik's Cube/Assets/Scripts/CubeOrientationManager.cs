using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOrientationManager : MonoBehaviour
{
    [SerializeField] private RotationManager rotationManager;
    [SerializeField] private string faceDirection = "NORTH"; // Which direction the face is pointing (NORTH // EAST // SOUTH // WEST)

    private void Start() // Initializes the RotationManager
    {
        if (rotationManager == null)
            rotationManager = this.GetComponentInParent<RotationManager>();
        
        rotateCubeLeft();
    }

    public void rotateCubeLeft() // Rotates the whole Rubik's Cube to the left
    {
        Face[] faces = rotationManager.getFaces();
        Face[] temp = faces;
        if (faceDirection.Equals("NORTH"))
        {
            
            rotationManager.updateColorOrientation();
        }
    }
}
