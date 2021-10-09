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

    public string getColorOrientation() // Returns orientation of the this Tile instance
    {
        return colorOrientation;
    }

    public int[] getCoords() // Returns the coordinates of this Tile instance
    {
        return new int[] { xCoord, yCoord };
    }

    public void setTileColorOrientation(string c) // Sets the color orientation of this Tile instance
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

   public void setCoords(int x, int y) // Sets the coordinates of this Tile instance
   {
        xCoord = x;
        yCoord = y;
   }

   private void initializeCoords() // Initializes the coordinates of this Tile instance
   {
        string objectName = this.gameObject.name;
        string coords = objectName = objectName.Substring(objectName.IndexOf("("));
        coords = coords.Trim();
        xCoord = int.Parse(coords.Substring(1, 1));
        yCoord = int.Parse(coords.Substring(3, 1));
   }

   public void initializeTile() // Initializes this Tile instance
   {
        attachedFace = this.transform.parent.GetComponent<Face>();
        cubeThemeManager = attachedFace.getCubeThemeManager();
        colorOrientation = attachedFace.getOrientation();
        setTileColorOrientation(colorOrientation);
        initializeCoords();
    }
}
