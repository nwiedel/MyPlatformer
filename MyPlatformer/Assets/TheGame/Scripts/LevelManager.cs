using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Levelmanager load!");
        SaveGameData.Load();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            SaveGameData.Load();
    }
}
