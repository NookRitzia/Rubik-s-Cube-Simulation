using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CubeMenuColorController cubeMenuController;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("CubeColorSet"))
            cubeMenuController.setDefaultsPrefsAndSlider();
    }

    public void PlaySimulation()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitSimulation()
    {
        Debug.Log("Quit.");    
        Application.Quit();  
    }

   



}
