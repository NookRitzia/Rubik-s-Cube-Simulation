using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Color tileColor;
    private int xCoord;
    private int yCoord;

    public Tile(Color c, int x, int y) // Constructor for Tile object which assigns color and coordinates of tile
    {
        setTileColor(c);
        setCoords(x, y);
    }

    public Color getColor() // Returns color of the Tile object
    {
        return tileColor;
    }

    public int[] getCoords() // Returns the coordinates of the Tile object
    {
        return new int[] { xCoord, yCoord };
    }

    public void setTileColor(Color c) // Sets the color of the tile
    {
        tileColor = c;
    }

   public void setCoords(int x, int y) // Sets the coordinates of the tile
   {
        xCoord = x;
        yCoord = y;
   }
}
