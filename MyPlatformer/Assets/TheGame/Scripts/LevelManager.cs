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

    public void LoadScene(string name)
    {
        Debug.Log("Lade jetzt Scene: " + name);
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            SaveGameData.current = SaveGameData.Load();
    }
}
