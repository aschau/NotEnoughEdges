using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void Restart()
    {
        MasterGameManager.instance.sceneManager.ReloadScene();
    }

    public void GoToMainMenu()
    {
        MasterGameManager.instance.sceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void LoadScene(string name)
    {
        MasterGameManager.instance.sceneManager.LoadScene(name);
    }
}
