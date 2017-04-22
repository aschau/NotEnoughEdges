using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerWrapper : MonoBehaviour {
    public delegate void OnSceneLoaded();
    public event OnSceneLoaded onSceneLoaded = delegate { };

    public string currentScene;

    void Awake()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.name;
        this.onSceneLoaded();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
