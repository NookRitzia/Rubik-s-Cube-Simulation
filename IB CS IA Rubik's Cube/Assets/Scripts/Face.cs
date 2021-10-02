using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private Tile[,] tiles;
    //[SerializeField] private Color centerColor;
    [SerializeField] private string orientation;
    [SerializeField] protected CubeThemeManager cubeThemeManager;

    private void Start()
    {
        
    }

    private void Update()
    {
       // if (tiles == null)
            //initializeTiles();
    }

    public Face(Tile[,] t, string o)
    {
        setTiles(t);
        setOrientation(o);
    }

    public CubeThemeManager getCubeThemeManager()
    {
        return cubeThemeManager;
    }

    public void initializeCubeThemeManager()
    {
        cubeThemeManager = this.gameObject.GetComponentInParent<CubeThemeManager>();
    }
    
    public string getTileColorOrientation(int x, int y)
    {
        return tiles[x,y].getColorOrientation();
    }

    public string getOrientation()
    {
        return orientation;
    }

    public string[,] getTileColorOrientations()
    {
        string[,] o = new string[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                o[i, j] = getTileColorOrientation(i, j);
        return o;
    }

    public void setOrientation(string o)
    {
        orientation = o;
    }

    public void setTileColorOrientation(int x, int y, string c)
    {
        tiles[x,y].setTileColorOrientation(c);
    }

    public void setTiles(Tile[,] newTiles)
    {
        tiles = newTiles;
    }

    private Tile[,] getTilesFromCube()
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

    public void initializeTiles()
    {
        setTiles(getTilesFromCube());
    }

    public Tile[,] getTiles()
    {
        return tiles;
    }
    


}
