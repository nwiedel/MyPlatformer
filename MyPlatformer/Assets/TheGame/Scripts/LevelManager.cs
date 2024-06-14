using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        SaveGameData.current = SaveGameData.Load();
    }

    private void Start()
    {
        LoadScene(SaveGameData.current.recentScene);
    }

    public void LoadScene(string name)
    {
        if (name == "")
        {
            return;
        }

        for (int i = SceneManager.sceneCount - 1; i > 0; i--)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i).name);
        }

            Debug.Log("Lade jetzt Scene: " + name);
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            SaveGameData.current = SaveGameData.Load();
    }
}
