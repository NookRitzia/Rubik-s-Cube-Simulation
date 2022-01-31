using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInitializationManager : MonoBehaviour
{
    /*
     *  Initializes the faces, Edge Color Manager and Tiles 
     *  associated with the Rubik's Cube
    */
    void Start()
    {
        Face[] faces = this.GetComponentsInChildren<Face>();
        EdgeColorManager eCM = this.GetComponentInChildren<EdgeColorManager>();
        eCM.initializeEdgeColors();

        foreach (Face face in faces)
        {
            face.initializeCubeThemeManager();
            Tile[] tiles = face.GetComponentsInChildren<Tile>();
            foreach (Tile tile in tiles)
            {
                tile.initializeTile();
            }
            face.initializeTiles();
            
        }
    }
}
