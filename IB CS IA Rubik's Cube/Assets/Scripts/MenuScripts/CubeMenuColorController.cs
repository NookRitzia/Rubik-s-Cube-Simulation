using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMenuColorController : MonoBehaviour
{
    [SerializeField] private string face;
    [SerializeField] private string color;
    [SerializeField] private GameObject fillObject;
    [SerializeField] private GameObject outputImage;

    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.GetString("CubeColorSet").Equals("true"))
            setDefaultsPrefsAndSlider();
    }

    public void setDefaultsPrefsAndSlider()
    {
        // FRONT - RED
        // BACK - YELLOW
        // LEFT - GREEN
        // RIGHT - BLUE
        // TOP - WHITE
        // BOTTOM - YELLOW
        PlayerPrefs.SetInt("FRONT-RED", 255);
        PlayerPrefs.SetInt("FRONT-GREEN", 0);
        PlayerPrefs.SetInt("FRONT-BLUE", 0);

        PlayerPrefs.SetInt("BACK-RED", 255);
        PlayerPrefs.SetInt("BACK-GREEN", 165);
        PlayerPrefs.SetInt("BACK-BLUE", 0);

        PlayerPrefs.SetInt("LEFT-RED", 0);
        PlayerPrefs.SetInt("LEFT-GREEN", 255);
        PlayerPrefs.SetInt("LEFT-BLUE", 0);

        PlayerPrefs.SetInt("RIGHT-RED", 0);
        PlayerPrefs.SetInt("RIGHT-GREEN", 0);
        PlayerPrefs.SetInt("RIGHT-BLUE", 255);

        PlayerPrefs.SetInt("TOP-RED", 255);
        PlayerPrefs.SetInt("TOP-GREEN", 255);
        PlayerPrefs.SetInt("TOP-BLUE", 255);

        PlayerPrefs.SetInt("BOTTOM-RED", 255);
        PlayerPrefs.SetInt("BOTTOM-GREEN", 255);
        PlayerPrefs.SetInt("BOTTOM-BLUE", 0);

        Slider[] sliders = this.GetComponentsInChildren<Slider>();
        Debug.Log(sliders[0]);
        foreach (Slider slider in sliders)
        {
            slider.value = slider.GetComponent<CubeMenuColorController>().getValue();
        }
    }

    public int getValue()
    {
        return PlayerPrefs.GetInt(face + "-" + color);
    }

    public void updateSlider()
    {
        PlayerPrefs.SetString("CubeColorSet", "true");
        Slider slider = this.GetComponent<Slider>();
        int value = (int)(slider.value);
        setColorPrefs(value);
        Color c;
        switch (color) {
            case "RED":
                c = new Color(value / 255f, 0, 0);
                break;
            case "GREEN":
                c = new Color(0, value / 255f, 0);
                break;
            case "BLUE":
                c = new Color(0, 0, value / 255f);
                break;
            default:
                c = Color.white;
                break;
        }
        fillObject.GetComponent<Image>().color = c;
        updateOutputImage();
    }

    public void updateOutputImage()
    {
        float r = PlayerPrefs.GetInt(face + "-RED") / 255f;
        float g = PlayerPrefs.GetInt(face + "-GREEN") / 255f;
        float b = PlayerPrefs.GetInt(face + "-BLUE") / 255f;


        outputImage.GetComponent<Image>().color = new Color(r, g, b);
    }

    public void setColorPrefs(int value)
    {
        
        PlayerPrefs.SetInt(face + "-" + color, value);
    }
}
