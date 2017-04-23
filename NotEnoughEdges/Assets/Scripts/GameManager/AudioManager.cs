using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    public float bgmVolume
    {
        get { return bgmPlayer.volume; }
        set { bgmPlayer.volume = value; }
    }
    public float sfxVolume
    {
        get { return sfxPlayer.volume; }
        set { sfxPlayer.volume = value; }
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxPlayer.PlayOneShot(clip, volume);
    }

    private void Awake()
    {
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        bgmVolume = PlayerPrefs.GetFloat("bgmVolume");
    }
}
