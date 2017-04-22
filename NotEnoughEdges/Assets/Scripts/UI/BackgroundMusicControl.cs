using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroundMusicControl : MonoBehaviour
{
    private Slider volumeController;

    void Start()
    {

        this.volumeController = this.GetComponent<Slider>();
        this.volumeController.value = MasterGameManager.instance.audioManager.bgmVolume;
    }

    public void setVolume()
    {
        MasterGameManager.instance.audioManager.bgmVolume = this.volumeController.value;
    }
}