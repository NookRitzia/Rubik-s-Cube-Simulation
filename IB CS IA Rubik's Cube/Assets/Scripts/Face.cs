using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    private Tile[][] tiles;
    private Color centerColor;
    private string orientation;

    public Face(Tile[][] t, string o)
    {
        setFace(t);
        setOrientation(o);
    }

    public Color getCenterColor()
    {
        return centerColor;
    }

    public Color getTileColor(int x, int y)
    {
        return tiles[x][y].getColor();
    }

    public string getOrientation()
    {
        return orientation;
    }

    public void setOrientation(string o)
    {
        orientation = o;
    }

    public void setTileColor(int x, int y, Color c)
    {
        tiles[x][y].setTileColor(c);
    }

    public void setFace(Tile[][] newTiles)
    {
        tiles = newTiles;
    }


}
