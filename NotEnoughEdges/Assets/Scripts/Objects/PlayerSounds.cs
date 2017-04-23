using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

    public AudioClip damageClip;
    public AudioClip edgeGainClip;

    void Awake()
    {
        this.GetComponent<ShapeManager>().onEdgeChange += OnEdgeChange;
    }

    void OnEdgeChange(int changeDelta)
    {
        AudioManager audioManager = MasterGameManager.instance.audioManager;
        
        if (changeDelta < 0)
        {
            audioManager.PlaySFX(damageClip, Random.Range(0.75f, 1));
        }
        else if (changeDelta > 0)
        {
            audioManager.PlaySFX(edgeGainClip, Random.Range(0.75f, 1));
        }
    }
}
