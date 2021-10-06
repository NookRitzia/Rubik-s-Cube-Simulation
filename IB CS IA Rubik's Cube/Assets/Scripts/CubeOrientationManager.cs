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

    private void switchFace(string face1, Face toCopy)
    {
        rotationManager.getFace(face1).setAllTileColorOrientation(toCopy.getTiles());
    }

    public void rotateCubeLeft()
    {
        Face[] faces = rotationManager.getFaces();
        Face[] temp = faces;
        if (faceDirection.Equals("NORTH"))
        {
            switchFace("FRONT", rotationManager.getFace("LEFT"));
            switchFace("LEFT", "BACK");
            switchFace("BACK", "RIGHT");
            switchFace("RIGHT", "FRONT");
            rotationManager.updateColorOrientation();
            // need to fix all face switching need to dereference variables
            Debug.Log("RUN");
        }
    }
}
