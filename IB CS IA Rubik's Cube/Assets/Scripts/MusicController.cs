using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] songs;
    [SerializeField] private AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Background Music"))
            PlayerPrefs.SetInt("Background Music", 0);
        if (!PlayerPrefs.HasKey("Background Music Volume"))
            PlayerPrefs.SetInt("Background Music Volume", 25);
        updateSong();
        audioPlayer.volume = PlayerPrefs.GetInt("Background Music Volume") / 100f;
        audioPlayer.loop = true;
        audioPlayer.enabled = false;
        audioPlayer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource getAudioPlayer()
    {
        return audioPlayer;
    }

    public void updateSong()
    {
        audioPlayer.clip = songs[PlayerPrefs.GetInt("Background Music")];
    }

    

}
