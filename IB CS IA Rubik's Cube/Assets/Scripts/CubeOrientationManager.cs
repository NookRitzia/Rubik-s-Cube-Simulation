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

    public void rotateCubeLeft()
    {
        Face[] faces = rotationManager.getFaces();
        Face[] temp = faces;
        if (faceDirection.Equals("NORTH"))
        {
            rotationManager.getFace("FRONT").setTiles(rotationManager.getFace("LEFT").getTiles());
            Debug.Log("RUN");
        }
    }

    


}
