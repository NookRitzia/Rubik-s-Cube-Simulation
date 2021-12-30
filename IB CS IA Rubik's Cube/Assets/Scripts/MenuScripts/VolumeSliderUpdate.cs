using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MusicController musicController;
    public void Start()
    {
        if (!PlayerPrefs.HasKey("Background Music Volume"))
            PlayerPrefs.SetInt("Background Music Volume", 25);
        this.GetComponent<Slider>().value = PlayerPrefs.GetInt("Background Music Volume");
    }

    public void UpdateSlider()
    {
        PlayerPrefs.SetInt("Background Music Volume", (int) this.GetComponent<Slider>().value);
        musicController.getAudioPlayer().volume = PlayerPrefs.GetInt("Background Music Volume") / 100f;
    }

}
