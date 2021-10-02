using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeColorManager : MonoBehaviour
{
    [SerializeField] private CubeThemeManager cubeThemeManager;
    [SerializeField] private Color color;
    [SerializeField] private Material material;
    private void Start()
    {
        

    }

    public void initializeEdgeColors()
    {
        cubeThemeManager = this.GetComponentInParent<CubeThemeManager>();
        color = cubeThemeManager.getEdgeColor();
        material = cubeThemeManager.getEdgeMaterial();
        MeshRenderer[] mRList = this.gameObject.transform.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer mR in mRList)
        {
            mR.material = material;
        }
    }
}
