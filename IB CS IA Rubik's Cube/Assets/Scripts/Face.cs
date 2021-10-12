using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private Tile[,] tiles;
    [SerializeField] private string orientation;
    [SerializeField] private CubeThemeManager cubeThemeManager;

    public CubeThemeManager getCubeThemeManager() // Returns the CubeThemeManager associated with this Face instance
    {
        return cubeThemeManager;
    }

    public void initializeCubeThemeManager() // Initializes the CubeThemeManager
    {
        cubeThemeManager = this.gameObject.GetComponentInParent<CubeThemeManager>();
    }
    
    public string getTileColorOrientation(int x, int y) // Returns the orientation of a specific tile where x and y are the corresponding indices
    {
        return tiles[x,y].getColorOrientation();
    }

    public string getOrientation() // Returns the orientation associated with this Face instance
    {
        return orientation;
    }

    public string[,] getTileColorOrientations() // Returns the orientation of all tiles associated with this Face instance
    {
        string[,] o = new string[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                o[i, j] = getTileColorOrientation(i, j);
        return o;
    }

    public void setOrientation(string o) // Sets the orientation of this Face instance
    {
        orientation = o;
    }

    public void setAllTileColorOrientation(string[,] o) // Sets the orientation of all tiles associated with this Face instance
    {
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                tiles[x, y].setTileColorOrientation(o[x,y]);
    }

    public void setTileColorOrientation(int x, int y, string c) // Sets the orientation of one tile associated with this Face with indices x and y
    {
        tiles[x,y].setTileColorOrientation(c);
    }

    public void setTiles(Tile[,] newTiles) // Sets all the tiles associated with this instance of Face
    {
        tiles = newTiles;
    }

    private Tile[,] getTilesFromCube() // Returns all tiles associated with this Face instance from the Rubik's Cube
    {
        Tile[,] t = new Tile[3,3];
        Tile[] tempTileArray = this.GetComponentsInChildren<Tile>();
        foreach (Tile tile in tempTileArray)
        {
            int[] coords = tile.getCoords();
            t[coords[0], coords[1]] = tile;
        }
        return t;
    }

    public void initializeTiles() // Initializes the tiles associated with this Face instance
    {
        setTiles(getTilesFromCube());
    }

    public Tile[,] getTiles() // Returns all tiles associated with this Face instance
    {
        return tiles;
    }
    public static Face getFace(Face[] f, string orientation) // Gets the Face with a specific orientation from an array of Faces
    {
        foreach (Face face in f)
        {
            if (face.getOrientation().Equals(orientation))
                return face;
        }
        throw new System.Exception("Invalid Orientation");
    }

    public static string[,] rotateOrientationClockwise(string[,] o) // Rotates the orientations (passed argument) clockwise
    {
        string[,] rotatedOrientation = new string[3, 3];
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                rotatedOrientation[x, y] = o[2 - y, x];
        return rotatedOrientation;
    }

    public static string[,] rotateOrientationCounterClockwise(string[,] o) // Rotates the orientations (passed argument) counter clockwise
    {
        string[,] rotatedOrientation = new string[3, 3];
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                rotatedOrientation[x, y] = o[y, 2 - x];
        return rotatedOrientation;
    }

    public static string[,] rotateOrientationClockwise(string[,] o, int count)
    {
        for (int i = 0; i < count; i++)
            o = rotateOrientationClockwise(o);
        return o;
    }

    public static string[,] rotateOrientationCounterClockwise(string[,] o, int count)
    {
        for (int i = 0; i < count; i++)
            o = rotateOrientationCounterClockwise(o);
        return o;
    }

}
