using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeThemeManager : MonoBehaviour
{
    [SerializeField] private Color topColor;
    [SerializeField] private Color bottomColor;
    [SerializeField] private Color leftColor;
    [SerializeField] private Color rightColor;
    [SerializeField] private Color frontColor;
    [SerializeField] private Color backColor;
    [SerializeField] private Color edgeColor;

    private Material topMaterial;
    private Material bottomMaterial;
    private Material leftMaterial;
    private Material rightMaterial;
    private Material frontMaterial;
    private Material backMaterial;
    private Material edgeMaterial;

    private void Start()
    {

        initializeMaterials();
        updateMaterialColors();
    }

    public CubeThemeManager(Color t, Color bo, Color l, Color r, Color f, Color ba)
    {
        setTopColor(t);
        setBottomColor(bo);
        setLeftColor(l);
        setRightColor(r);
        setFrontColor(f);
        setBackColor(ba);

        initializeMaterials();
        updateMaterialColors();
    }

    public void updateMaterialColors()
    {
        topMaterial.color = topColor;
        bottomMaterial.color = bottomColor;
        leftMaterial.color = leftColor;
        rightMaterial.color = rightColor;
        frontMaterial.color = frontColor;
        backMaterial.color = backColor;
        edgeMaterial.color = edgeColor;
    }

    private void initializeMaterials()
    {
        topMaterial = new Material(Shader.Find("Standard"));
        bottomMaterial = new Material(Shader.Find("Standard"));
        leftMaterial = new Material(Shader.Find("Standard"));
        rightMaterial = new Material(Shader.Find("Standard"));
        frontMaterial = new Material(Shader.Find("Standard"));
        backMaterial = new Material(Shader.Find("Standard"));
        edgeMaterial = new Material(Shader.Find("Standard"));
    }

    public Color getTopColor()
    {
        return topColor;
    }
    public Color getBottomColor()
    {
        return bottomColor;
    }
    public Color getLeftColor()
    {
        return leftColor;
    }
    public Color getRightColor()
    {
        return rightColor;
    }

    public Color getFrontColor()
    {
        return frontColor;
    }

    public Color getBackColor()
    {
        return backColor;
    }

    public Color getEdgeColor()
    {
        return edgeColor;
    }

    public Material getTopMaterial()
    {
        return topMaterial;
    }

    public Material getBottomMaterial()
    {
        return bottomMaterial;
    }

    public Material getLeftMaterial()
    {
        return leftMaterial;
    }

    public Material getRightMaterial()
    {
        return rightMaterial;
    }

    public Material getFrontMaterial()
    {
        return frontMaterial;
    }

    public Material getBackMaterial()
    {
        return backMaterial;
    }

    public Material getEdgeMaterial()
    {
        return edgeMaterial;
    }

    public void setTopColor(Color c)
    {
        topColor = c;
        topMaterial.color = c;
    }

    public void setBottomColor(Color c)
    {
        bottomColor = c;
        bottomMaterial.color = c;
    }

    public void setLeftColor(Color c)
    {
        leftColor = c;
        leftMaterial.color = c;
    }

    public void setRightColor(Color c)
    {
        rightColor = c;
        rightMaterial.color = c;
    }

    public void setFrontColor(Color c)
    {
        frontColor = c;
        frontMaterial.color = c;
    }

    public void setBackColor(Color c)
    {
        backColor = c;
        backMaterial.color = c;
    }

    public void setEdgeColor(Color c)
    {
        edgeColor = c;
        edgeMaterial.color = c;
    }
}
