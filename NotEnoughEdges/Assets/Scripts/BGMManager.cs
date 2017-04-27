using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {

    public List<AudioClip> trackList;
    private int currentTrackIndex = -1;
    private AudioSource source;

    void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayRandomTrack();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayRandomTrack();
        }

        if (!source.isPlaying)
        {
            PlayRandomTrack();
        }
    }

    void PlayRandomTrack()
    {
        List<int> possibleTracks = new List<int>();
        for (int i = 0; i < trackList.Count; i++)
            possibleTracks.Add(i);
        if (currentTrackIndex >= 0)
            possibleTracks.RemoveAt(currentTrackIndex);

        int newTrackIndex = possibleTracks[Random.Range(0, possibleTracks.Count)];
        currentTrackIndex = newTrackIndex;

        source.clip = trackList[currentTrackIndex];
        source.Play();
    }
}
