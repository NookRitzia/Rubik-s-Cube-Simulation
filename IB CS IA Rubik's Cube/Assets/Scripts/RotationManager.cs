using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    private Face[] faces; // Array of faces

    private string[,] topColorOrientation; // Array of top tile colors [x,y]
    private string[,] bottomColorOrientation; // Array bottom top tile colors [x,y]
    private string[,] leftColorOrientation; // Array of left tile colors [x,y]
    private string[,] rightColorOrientation; // Array of right tile colors [x,y]
    private string[,] frontColorOrientation; // Array of front tile colors [x,y]
    private string[,] backColorOrientation; // Array of back tile colors [x,y]


    private void Start() // Assigning faces variable with a reference to the Rubik's Cube's Faces
    {
        faces = this.GetComponentsInChildren<Face>();
        updateColorOrientation();
    }

    public void updateColorOrientation() // Updates the color orientation string arrays
    {
        topColorOrientation = getFace("TOP").getTileColorOrientations();
        bottomColorOrientation = getFace("BOTTOM").getTileColorOrientations();
        leftColorOrientation = getFace("LEFT").getTileColorOrientations();
        rightColorOrientation = getFace("RIGHT").getTileColorOrientations();
        frontColorOrientation = getFace("FRONT").getTileColorOrientations();
        backColorOrientation = getFace("BACK").getTileColorOrientations();
    }

    public string[,] getTopColorOrientation() // Returns the top color orientation string array
    {
        return topColorOrientation;
    }

    public string[,] getBottomColorOrientation() // Returns the bottom color orientation string array
    {
        return bottomColorOrientation;
    }

    public string[,] getLeftColorOrientation() // Returns the left color orientation string array
    {
        return leftColorOrientation;
    }

    public string[,] getRightColorOrientation() // Returns the right color orientation string array
    {
        return rightColorOrientation;
    }

    public string[,] getFrontColorOrientation() // Returns the front color orientation string array
    {
        return frontColorOrientation;
    }

    public string[,] getBackColorOrientation() // Returns the back color orientation string array
    {
        return backColorOrientation;
    }

    private Face getFace(string orientation) // Returns the specific Face with a certain orientation
    {
        return Face.getFace(faces, orientation);
    }

    public Face[] getFaces() // Returns all faces of the Rubik's Cube as an array
    {
        return faces;
    }

    public void rotateTop(int count) // Rotates the top face of the Rubik's Cube
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

    public void rotateRight(int count) // Rotates the right face of the Rubik's Cube
    {
        for (int c = 0; c < count; c++)
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

    public void rotateFront(int count) // Rotes the front face of the Rubik's Cube
    {
        for (int c = 0; c < count; c++)
        {
            
            for (int i = 0; i < 3; i++)
            {
                getFace("TOP").setTileColorOrientation(i, 0, leftColorOrientation[2, i]);
                getFace("LEFT").setTileColorOrientation(2, i, bottomColorOrientation[2 - i, 2]);
                getFace("BOTTOM").setTileColorOrientation(i, 2, rightColorOrientation[0, i]); 
                getFace("RIGHT").setTileColorOrientation(0, i, topColorOrientation[2 - i, 0]); 
            }

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    getFace("FRONT").setTileColorOrientation(x, y, frontColorOrientation[2 - y, x]);

            updateColorOrientation();
        }
    }

    public void rotateLeft(int count) // Rotates the left face of the Rubik's Cube
    {
        for (int c = 0; c < count; c++)
        {
            for (int i = 0; i < 3; i++)
            {
                getFace("TOP").setTileColorOrientation(0, i, backColorOrientation[2, 2 - i]);
                getFace("FRONT").setTileColorOrientation(0, i, topColorOrientation[0, i]);
                getFace("BOTTOM").setTileColorOrientation(0, i, frontColorOrientation[0, i]);
                getFace("BACK").setTileColorOrientation(2, i, bottomColorOrientation[0, 2 - i]);
            }

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    getFace("LEFT").setTileColorOrientation(x, y, leftColorOrientation[2 - y, x]);


            updateColorOrientation();
        }
    }

    public void rotateBottom(int count) // Rotates the bottom face of the Rubik's Cube
    {
        for (int c = 0; c < count; c++)
        {
            for (int i = 0; i < 3; i++)
            {
                getFace("FRONT").setTileColorOrientation(i, 0, leftColorOrientation[i, 0]);
                getFace("RIGHT").setTileColorOrientation(i, 0, frontColorOrientation[i, 0]);
                getFace("BACK").setTileColorOrientation(i, 0, rightColorOrientation[i, 0]);
                getFace("LEFT").setTileColorOrientation(i, 0, backColorOrientation[i, 0]);
            }

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    getFace("BOTTOM").setTileColorOrientation(x, y, bottomColorOrientation[2 - y, x]);

            updateColorOrientation();
        }
    }

    public void rotateBack(int count) // Rotates the back face of the Rubik's Cube
    {
        for (int c = 0; c < count; c++)
        {
            for (int i = 0; i < 3; i++)
            {
                getFace("TOP").setTileColorOrientation(i, 2, rightColorOrientation[2, 2 - i]);
                getFace("LEFT").setTileColorOrientation(0, i, topColorOrientation[i, 2]);
                getFace("BOTTOM").setTileColorOrientation(i, 0, leftColorOrientation[0, 2 - i]);
                getFace("RIGHT").setTileColorOrientation(2, i, bottomColorOrientation[i, 0]);
            }

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    getFace("BACK").setTileColorOrientation(x, y, backColorOrientation[2 - y, x]);

            updateColorOrientation();
        }
    }

    public void rotateMiddleHorizontal(int count) // Rotates the middle row of the Rubik's Cube
    {
        for (int c = 0; c < count; c++)
        {
            for (int i = 0; i < 3; i++)
            {
                getFace("FRONT").setTileColorOrientation(i, 1, rightColorOrientation[i, 1]);
                getFace("LEFT").setTileColorOrientation(i, 1, frontColorOrientation[i, 1]);
                getFace("BACK").setTileColorOrientation(i, 1, leftColorOrientation[i, 1]);
                getFace("RIGHT").setTileColorOrientation(i, 1, backColorOrientation[i, 1]);
            }

            updateColorOrientation();
        }
    }

    public void rotateMiddleVertical(int count) // Rotates the middle column of the Rubik's Cube
    {
        for (int c = 0; c < count; c++)
        {
            for (int i = 0; i < 3; i++)
            {
                getFace("BACK").setTileColorOrientation(1, i, topColorOrientation[1, 2 - i]);
                getFace("TOP").setTileColorOrientation(1, i, frontColorOrientation[1, i]);
                getFace("FRONT").setTileColorOrientation(1, i, bottomColorOrientation[1, i]);
                getFace("BOTTOM").setTileColorOrientation(1, i, backColorOrientation[1, 2 - i]);
            }

            updateColorOrientation();
        }
    }

    public void randomize(int rotations) // Scrambles the Rubik's Cube
    {
        int randomNum;
        for (int i = 0; i < rotations; i++)
        {
            randomNum = Random.Range(0, 6);
            switch (randomNum)
            {
                case 0:
                    rotateLeft(1);
                    break;
                case 1:
                    rotateRight(1);
                    break;
                case 2:
                    rotateTop(1);
                    break;
                case 3:
                    rotateBottom(1);
                    break;
                case 4:
                    rotateFront(1);
                    break;
                case 5:
                    rotateBack(1);
                    break;
            }
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
        if (Input.GetKeyDown(KeyCode.F))
            rotateLeft(1);
        if (Input.GetKeyDown(KeyCode.G))
            rotateBottom(1);
        if (Input.GetKeyDown(KeyCode.H))
            rotateBack(1);

        if (Input.GetKeyDown(KeyCode.K))
            rotateMiddleHorizontal(1);
        if (Input.GetKeyDown(KeyCode.L))
            rotateMiddleVertical(1);

        if (Input.GetKeyDown(KeyCode.Semicolon))
            randomize(300);
    }
}
