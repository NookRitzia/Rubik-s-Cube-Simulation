using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInitializationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Face[] faces = this.GetComponentsInChildren<Face>();
        EdgeColorManager eCM = this.GetComponentInChildren<EdgeColorManager>();
        eCM.initializeEdgeColors();

        foreach (Face face in faces)
        {
            Tile[] tiles = face.GetComponentsInChildren<Tile>();
            foreach (Tile tile in tiles)
            {
                tile.initializeTile();
            }
            face.initializeTiles();
        }
    }
}
