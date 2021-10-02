using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private Tile[][] tiles;
    //[SerializeField] private Color centerColor;
    [SerializeField] private string orientation;
    [SerializeField] protected CubeThemeManager cubeThemeManager;

    private void Start()
    {
        cubeThemeManager = this.gameObject.GetComponentInParent<CubeThemeManager>();
    }

    public Face(Tile[][] t, string o)
    {
        setFace(t);
        setOrientation(o);
    }

    public CubeThemeManager getCubeThemeManager()
    {
        return cubeThemeManager;
    }
    
    public string getTileColorOrientation(int x, int y)
    {
        return tiles[x][y].getColorOrientation();
    }

    public string getOrientation()
    {
        return orientation;
    }

    public void setOrientation(string o)
    {
        orientation = o;
    }

    public void setTileColorOrientation(int x, int y, string c)
    {
        tiles[x][y].setTileColor(c);
    }

    public void setFace(Tile[][] newTiles)
    {
        tiles = newTiles;
    }


}
