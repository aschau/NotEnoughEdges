using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {
    public static bool paused;
    private Rigidbody2D player;
    private Vector2 originalPlayerVelocity;
    private float originalPlayerAngularVelocity;
    private GameObject pauseMenu, settingsMenu;
    void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        this.pauseMenu = GameObject.Find("Pause Menu");
        this.settingsMenu = GameObject.Find("Settings Menu");
    }

	// Use this for initialization
	void Start () {
        paused = false;
        this.pauseMenu.SetActive(false);
        this.settingsMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void togglePause()
    {
        paused = !paused;
        this.pauseMenu.SetActive(!this.pauseMenu.activeSelf);

        if (paused)
        {
            this.originalPlayerVelocity = this.player.velocity;
            this.originalPlayerAngularVelocity = this.player.angularVelocity;
            this.player.isKinematic = true;
            this.player.velocity = Vector2.zero;
            this.player.angularVelocity = 0;
        }

        else
        {
            this.player.isKinematic = false;
            this.player.velocity = this.originalPlayerVelocity;
            this.player.angularVelocity = this.originalPlayerAngularVelocity;
        }
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void toggleSettings()
    {
        this.settingsMenu.SetActive(!this.settingsMenu.activeSelf);   
    }
}
