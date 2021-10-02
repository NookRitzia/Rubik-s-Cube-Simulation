using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private string colorOrientation;
    [SerializeField] private int xCoord;
    [SerializeField] private int yCoord;
    [SerializeField] private Face attachedFace;
    [SerializeField] private CubeThemeManager cubeThemeManager;

    private void Start()
    {
        attachedFace = this.transform.parent.GetComponent<Face>();
        cubeThemeManager = attachedFace.getCubeThemeManager();
        colorOrientation = attachedFace.getOrientation();
        setTileColor(colorOrientation);
    }

    public Tile(string c, int x, int y) // Constructor for Tile object which assigns color and coordinates of tile
    {
        setTileColor(c);
        setCoords(x, y);
    }

    public string getColorOrientation() // Returns color orientation of the Tile object
    {
        return colorOrientation;
    }

    public int[] getCoords() // Returns the coordinates of the Tile object
    {
        return new int[] { xCoord, yCoord };
    }

    public void setTileColor(string c) // Sets the color orientation of the tile
    {
        colorOrientation = c;
        Material tempM;

        switch (c){
            case "TOP":
                tempM = cubeThemeManager.getTopMaterial();
                break;
            case "BOTTOM":
                tempM = cubeThemeManager.getBottomMaterial();
                break;
            case "LEFT":
                tempM = cubeThemeManager.getLeftMaterial();
                break;
            case "RIGHT":
                tempM = cubeThemeManager.getRightMaterial();
                break;
            case "FRONT":
                tempM = cubeThemeManager.getFrontMaterial();
                break;
            case "BACK":
                tempM = cubeThemeManager.getBackMaterial();
                break;
            default:
                Debug.Log(" Tile.setTileColor(string c) ERROR - " + this.gameObject);
                tempM = null;
                break;
        }
        this.gameObject.GetComponent<MeshRenderer>().material = tempM;
    }

   public void setCoords(int x, int y) // Sets the coordinates of the tile
   {
        xCoord = x;
        yCoord = y;
   }
}
