using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    private Face[] faces;



    private string[,] topColorOrientation;
    private string[,] bottomColorOrientation;
    private string[,] leftColorOrientation;
    private string[,] rightColorOrientation;
    private string[,] frontColorOrientation;
    private string[,] backColorOrientation;


    private void Start()
    {
        faces = this.GetComponentsInChildren<Face>();
        updateColorOrientation();
        
    }

    private void updateColorOrientation()
    {
        topColorOrientation = getFace("TOP").getTileColorOrientations();
        bottomColorOrientation = getFace("BOTTOM").getTileColorOrientations();
        leftColorOrientation = getFace("LEFT").getTileColorOrientations();
        rightColorOrientation = getFace("RIGHT").getTileColorOrientations();
        frontColorOrientation = getFace("FRONT").getTileColorOrientations();
        backColorOrientation = getFace("BACK").getTileColorOrientations();
    }

    public Face getFace(string orientation)
    {
        foreach (Face face in faces)
        {
            if (face.getOrientation().Equals(orientation))
                return face;
        }
        throw new System.Exception("Invalid Orientation");
    }

    public Face getFace(Face[] f, string orientation)
    {
        foreach (Face face in f)
        {
            if (face.getOrientation().Equals(orientation))
                return face;
        }
        throw new System.Exception("Invalid Orientation");
    }

    public void rotateTop(int count)
    {
        for (int c = 0; c < count; c++)
        {
            for (int i = 0; i < 3; i++)
            {
                getFace("FRONT").setTileColorOrientation(i, 2, rightColorOrientation[i, 2]);
                getFace("LEFT").setTileColorOrientation(i, 2, frontColorOrientation[i, 2]);
                getFace("BACK").setTileColorOrientation(i, 2, leftColorOrientation[i, 2]);
                getFace("RIGHT").setTileColorOrientation(i, 2, backColorOrientation[i, 2]);
            }

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    getFace("TOP").setTileColorOrientation(x, y, topColorOrientation[2 - y, x]);

            updateColorOrientation();
        }
    }


    public void rotateRight(int count)
    {
        for (int c = 0; c < count; count++)
        {
            for (int i = 0; i < 3; i++)
            {
                getFace("BACK").setTileColorOrientation(0, i, topColorOrientation[2, 2 - i]);
                getFace("TOP").setTileColorOrientation(2, i, frontColorOrientation[2, i]);
                getFace("FRONT").setTileColorOrientation(2, i, bottomColorOrientation[2, i]);
                getFace("BOTTOM").setTileColorOrientation(2, i, backColorOrientation[0, 2 - i]);
            }

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    getFace("RIGHT").setTileColorOrientation(x, y, rightColorOrientation[2 - y, x]);

            updateColorOrientation();
        }
    }

    public void rotateFront(int count)
    {
        for (int c = 0; c < count; count++)
        {
            for (int i = 0; i < 3; i++)
            {
                getFace("TOP").setTileColorOrientation(i, 0, rightColorOrientation[0, 2 - i]);
                getFace("LEFT").setTileColorOrientation(2, i, topColorOrientation[i, 0]);
                getFace("BOTTOM").setTileColorOrientation(i, 2, leftColorOrientation[2, 2 - i]);
                getFace("RIGHT").setTileColorOrientation(0, i, bottomColorOrientation[i, 2]);
            }

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    getFace("FRONT").setTileColorOrientation(x, y, frontColorOrientation[2 - y, x]);

            updateColorOrientation();
        }
    }





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            rotateTop(1);
        if (Input.GetKeyDown(KeyCode.S))
            rotateRight(1);
        if (Input.GetKeyDown(KeyCode.D))
            rotateFront(1);
    }
}
