using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public delegate void OnPause(bool isPaused);
    public event OnPause onPause = delegate { };

    public bool isPaused = false;
    //private Rigidbody2D player;
    //private Vector2 originalPlayerVelocity;
    //private float originalPlayerAngularVelocity;

    PauseMenu pauseMenu;

    void Awake()
    {
        MasterGameManager.instance.sceneManager.onSceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded()
    {
        //this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        pauseMenu = GameObject.Find("Pause Menu").GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePause(!isPaused);
        }
    }

    public void EnablePause(bool active)
    {
        //Time.timeScale = active ? 0 : 1;

        if (pauseMenu != null)
        {
            pauseMenu.EnablePanel(active);
        }

        //if (active)
        //{
        //    this.originalPlayerVelocity = this.player.velocity;
        //    this.originalPlayerAngularVelocity = this.player.angularVelocity;
        //    this.player.isKinematic = true;
        //    this.player.velocity = Vector2.zero;
        //    this.player.angularVelocity = 0;
        //}

        //else
        //{
        //    this.player.isKinematic = false;
        //    this.player.velocity = this.originalPlayerVelocity;
        //    this.player.angularVelocity = this.originalPlayerAngularVelocity;
        //}

        isPaused = active;

        onPause(active);
    }
}
