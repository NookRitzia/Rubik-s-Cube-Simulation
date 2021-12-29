using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTheme : MonoBehaviour
{
    [SerializeField] Material[] skyboxMaterials;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Theme"))
            PlayerPrefs.SetInt("Theme", 0);
        RenderSettings.skybox = skyboxMaterials[PlayerPrefs.GetInt("Theme")];
    }

}
