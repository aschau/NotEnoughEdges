using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroundMusicControl : MonoBehaviour
{
    public static float sliderAmount = 1f;
    private AudioSource backgroundMusic;
    private Slider volumeController;
    private float originalVolume;

    void Awake()
    {

        this.backgroundMusic = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        this.volumeController = this.GetComponent<Slider>();
        this.originalVolume = this.backgroundMusic.volume;
        this.backgroundMusic.volume = this.originalVolume * sliderAmount;
        this.volumeController.value = sliderAmount;

    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setVolume()
    {
        sliderAmount = this.volumeController.value;
        this.backgroundMusic.volume = this.originalVolume * this.volumeController.value;
    }
}