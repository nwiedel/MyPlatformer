using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        SaveGameData.current = SaveGameData.Load();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            SaveGameData.current = SaveGameData.Load();
    }
}
