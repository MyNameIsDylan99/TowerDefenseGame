using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private void Start()
    {
            
    }
    public List<AudioSource> MusicList;
    public AudioSource PopSound;
    public void PlayMusic()
    {
        foreach (var AudioSource in MusicList)
        {
            AudioSource.Stop();
        }
        MusicList[GameObject.Find("MusicDropdown").GetComponent<Dropdown>().value].Play();

    }
    public void ChangeVolume()
    {
        foreach (AudioSource AudioSource in MusicList)
        {
            AudioSource.volume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
        }
    }
    public void PlayPopSound()
    {
        PopSound.Play();
    }

}
//MusicList[GameObject.Find("MusicDropdown").GetComponent<Dropdown>().value]