using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private CubeMenuColorController cubeMenuController;
    [SerializeField] private MusicController musicController;
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

    public void OpenTutorial(int a)
    {
        string url;
        switch (a)
        {
            case 0:
                url = "https://www.rubiks.com/en-uk/rubiks-cube-3x3-guide#content1";
                break;
            case 1:
                url = "https://ruwix.com/the-rubiks-cube/how-to-solve-the-rubiks-cube-beginners-method/";
                break;
            default:
                url = "https://ruwix.com/the-rubiks-cube/how-to-solve-the-rubiks-cube-beginners-method/";
                break;
        }
        Application.OpenURL(url);
    }

    public void SetTheme(int a)
    {
        PlayerPrefs.SetInt("Theme", a);
    }

    public void SetSong(int a)
    {
        PlayerPrefs.SetInt("Background Music", a);
        musicController.updateSong();
        musicController.getAudioPlayer().enabled = false;
        musicController.getAudioPlayer().enabled = true;
        
    }

}
