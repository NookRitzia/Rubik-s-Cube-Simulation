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

    private void Start() // Initializes material colors
    {
        if (PlayerPrefs.HasKey("CubeColorSet"))
            getCubeThemeFromPrefs();
        
        initializeMaterials();
        updateMaterialColors();
    }

    private void getCubeThemeFromPrefs()
    {
        int r = PlayerPrefs.GetInt("TOP-RED");
        int g = PlayerPrefs.GetInt("TOP-GREEN");
        int b = PlayerPrefs.GetInt("TOP-BLUE");
        Color color = new Color(r/255f, g/255f, b/255f);
        topColor = color;

        r = PlayerPrefs.GetInt("BOTTOM-RED");
        g = PlayerPrefs.GetInt("BOTTOM-GREEN");
        b = PlayerPrefs.GetInt("BOTTOM-BLUE");
        color = new Color(r / 255f, g / 255f, b / 255f);
        bottomColor = color;

        r = PlayerPrefs.GetInt("LEFT-RED");
        g = PlayerPrefs.GetInt("LEFT-GREEN");
        b = PlayerPrefs.GetInt("LEFT-BLUE");
        color = new Color(r / 255f, g / 255f, b / 255f);
        leftColor = color;

        r = PlayerPrefs.GetInt("RIGHT-RED");
        g = PlayerPrefs.GetInt("RIGHT-GREEN");
        b = PlayerPrefs.GetInt("RIGHT-BLUE");
        color = new Color(r / 255f, g / 255f, b / 255f);
        rightColor = color;

        r = PlayerPrefs.GetInt("FRONT-RED");
        g = PlayerPrefs.GetInt("FRONT-GREEN");
        b = PlayerPrefs.GetInt("FRONT-BLUE");
        color = new Color(r / 255f, g / 255f, b / 255f);
        frontColor = color;

        r = PlayerPrefs.GetInt("BACK-RED");
        g = PlayerPrefs.GetInt("BACK-GREEN");
        b = PlayerPrefs.GetInt("BACK-BLUE");
        color = new Color(r / 255f, g / 255f, b / 255f);
        backColor = color;

    }

    public void updateMaterialColors() // Updates all material colors
    {
        topMaterial.color = topColor;
        bottomMaterial.color = bottomColor;
        leftMaterial.color = leftColor;
        rightMaterial.color = rightColor;
        frontMaterial.color = frontColor;
        backMaterial.color = backColor;
        edgeMaterial.color = edgeColor;
    }

    private void initializeMaterials() // Initializes all materials
    {
        topMaterial = new Material(Shader.Find("Standard"));
        bottomMaterial = new Material(Shader.Find("Standard"));
        leftMaterial = new Material(Shader.Find("Standard"));
        rightMaterial = new Material(Shader.Find("Standard"));
        frontMaterial = new Material(Shader.Find("Standard"));
        backMaterial = new Material(Shader.Find("Standard"));
        edgeMaterial = new Material(Shader.Find("Standard"));
    }

    public Color getTopColor() // Returns the top side color of the Rubik's Cube
    {
        return topColor;
    }
    public Color getBottomColor() // Returns the bottom side color of the Rubik's Cube
    {
        return bottomColor;
    }
    public Color getLeftColor() // Returns the left side color of the Rubik's Cube
    {
        return leftColor;
    }
    public Color getRightColor() // Returns the right side color of the Rubik's Cube
    {
        return rightColor;
    }

    public Color getFrontColor() // Returns the front side color of the Rubik's Cube
    {
        return frontColor;
    }

    public Color getBackColor() // Returns the back side color of the Rubik's Cube
    {
        return backColor;
    }

    public Color getEdgeColor() // Returns the edge color of the Rubik's Cube
    {
        return edgeColor;
    }

    public Material getTopMaterial() // Returns the top side material
    {
        return topMaterial;
    }

    public Material getBottomMaterial() // Returns the bottom side material
    {
        return bottomMaterial;
    }

    public Material getLeftMaterial() // Returns the left side material
    {
        return leftMaterial;
    }

    public Material getRightMaterial() // Returns the right side material
    {
        return rightMaterial;
    }

    public Material getFrontMaterial() // Returns the front side material
    {
        return frontMaterial;
    }

    public Material getBackMaterial() // Returns the back side material
    {
        return backMaterial;
    }

    public Material getEdgeMaterial() // Returns the edge's material
    {
        return edgeMaterial;
    }

    public void setTopColor(Color c) // Sets the top side's color
    {
        topColor = c;
        topMaterial.color = c;
    }

    public void setBottomColor(Color c) // Sets the bottom side's color
    {
        bottomColor = c;
        bottomMaterial.color = c;
    }

    public void setLeftColor(Color c) // Sets the left side's color
    {
        leftColor = c;
        leftMaterial.color = c;
    }

    public void setRightColor(Color c) // Sets the right side's color
    {
        rightColor = c;
        rightMaterial.color = c;
    }

    public void setFrontColor(Color c) // Sets the front side's color
    {
        frontColor = c;
        frontMaterial.color = c;
    }

    public void setBackColor(Color c) // Sets the back side's color
    {
        backColor = c;
        backMaterial.color = c;
    }

    public void setEdgeColor(Color c) // Sets the color of the edges
    {
        edgeColor = c;
        edgeMaterial.color = c;
    }
}
