using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundEffectsControl : MonoBehaviour
{
    public static float sliderAmount = 1f;

    private GameObject[] soundEffects;
    private float[] soundEffectVolumes;
    private Slider volumeController;

    void Awake()
    {
        this.soundEffects = GameObject.FindGameObjectsWithTag("Sound");
        this.soundEffectVolumes = new float[this.soundEffects.Length];
        this.volumeController = this.GetComponent<Slider>();

        for (int i = 0; i < soundEffects.Length; i++)
        {
            this.soundEffectVolumes[i] = this.soundEffects[i].GetComponent<AudioSource>().volume;
        }

        for (int i = 0; i < this.soundEffects.Length; i++)
        {
            this.soundEffects[i].GetComponent<AudioSource>().volume = this.soundEffectVolumes[i] * sliderAmount;
        }

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
        for (int i = 0; i < this.soundEffects.Length; i++)
        {
            this.soundEffects[i].GetComponent<AudioSource>().volume = this.soundEffectVolumes[i] * this.volumeController.value;
        }
        sliderAmount = this.volumeController.value;
    }
}