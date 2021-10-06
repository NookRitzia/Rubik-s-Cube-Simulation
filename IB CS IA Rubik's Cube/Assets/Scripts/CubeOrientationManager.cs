using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOrientationManager : MonoBehaviour
{
    [SerializeField] private RotationManager rotationManager;
    [SerializeField] private string faceDirection = "NORTH"; // Which direction the face is pointing (NORTH // EAST // SOUTH // WEST)

    private void Start()
    {
        if (rotationManager == null)
            rotationManager = this.GetComponentInParent<RotationManager>();
        
        rotateCubeLeft();
        
    }

    private void switchFace(string face1, string face2)
    {
        rotationManager.getFace(face1).setAllTileColorOrientation(rotationManager.getFace(face2).getTiles());
    }

    public void rotateCubeLeft()
    {
        Face[] faces = rotationManager.getFaces();
        Face[] temp = faces;
        if (faceDirection.Equals("NORTH"))
        {
            switchFace("FRONT", "LEFT");
            switchFace("LEFT", "BACK");
            // need to fix all face switching need to dereference variables
            Debug.Log("RUN");
        }
    }
}
