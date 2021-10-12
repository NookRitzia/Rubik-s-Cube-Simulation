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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            rotateCubeUp();

            Debug.Log("HIT");
        }
    }

    public void rotateCubeRight() // Rotates the whole Rubik's Cube to the left
    {
        Face[] faces = rotationManager.getFaces();

        string[,] leftOrientation = rotationManager.getLeftColorOrientation();
        string[,] rightOrientation = rotationManager.getRightColorOrientation();
        string[,] topOrientation = rotationManager.getTopColorOrientation();
        string[,] bottomOrientation = rotationManager.getBottomColorOrientation();
        string[,] frontOrientation = rotationManager.getFrontColorOrientation();
        string[,] backOrientation = rotationManager.getBackColorOrientation();

        Face.getFace(faces, "FRONT").setAllTileColorOrientation(leftOrientation);
        Face.getFace(faces, "LEFT").setAllTileColorOrientation(backOrientation);
        Face.getFace(faces, "BACK").setAllTileColorOrientation(Face.rotateOrientationClockwise(rightOrientation,1));
        Face.getFace(faces, "RIGHT").setAllTileColorOrientation(frontOrientation);
        Face.getFace(faces, "TOP").setAllTileColorOrientation(Face.rotateOrientationCounterClockwise(topOrientation,1));
        Face.getFace(faces, "BOTTOM").setAllTileColorOrientation(Face.rotateOrientationClockwise(bottomOrientation,1));

        rotationManager.updateColorOrientation();
    }

    public void rotateCubeUp() // Rotates the whole Rubik's Cube upwards
    {
        Face[] faces = rotationManager.getFaces();

        string[,] leftOrientation = rotationManager.getLeftColorOrientation();
        string[,] rightOrientation = rotationManager.getRightColorOrientation();
        string[,] topOrientation = rotationManager.getTopColorOrientation();
        string[,] bottomOrientation = rotationManager.getBottomColorOrientation();
        string[,] frontOrientation = rotationManager.getFrontColorOrientation();
        string[,] backOrientation = rotationManager.getBackColorOrientation();

        Face.getFace(faces, "FRONT").setAllTileColorOrientation(bottomOrientation);
        Face.getFace(faces, "LEFT").setAllTileColorOrientation(Face.rotateOrientationCounterClockWise(leftOrientation,1));
        Face.getFace(faces, "BACK").setAllTileColorOrientation(Face.rotateOrientationClockwise(topOrientation,2));
        Face.getFace(faces, "RIGHT").setAllTileColorOrientation(Face.rotateOrientationClockWise(rightOrientation,1));
        Face.getFace(faces, "TOP").setAllTileColorOrientation(frontOrientation);
        Face.getFace(faces, "BOTTOM").setAllTileColorOrientation(Face.rotateOrientationClockwise(backOrientation,2));

        rotationManager.updateColorOrientation();
    }
}
