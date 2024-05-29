using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevProfi.Utils;
using System.IO;

[Serializable]
public class SaveGameData
{
    /// <summary>
    /// Refgerenz der Spielerposition.
    /// </summary>
    public Vector3 playerPosition = Vector3.zero;

    /// <summary>
    /// liefert den Pfad und den Dateinamen der Speicherdatei.
    /// </summary>
    /// <returns>Speicherpfad und Dateiname</returns>
    private static string GetFilename()
    {
        return Application.persistentDataPath + 
            Path.DirectorySeparatorChar + 
            "savegame.xml";
    }

    /// <summary>
    /// Speichert den Spielstand
    /// </summary>
    public void Save()
    {
        Debug.Log("Speichere Spielstand!" + GetFilename());

        Player player = Component.FindObjectOfType<Player>();
        playerPosition = player.transform.position;

        string xml = XML.Save(this);

        File.WriteAllText(GetFilename(), xml);
    }

    /// <summary>
    /// läd den Spielstand
    /// </summary>
    /// <returns></returns>
    public static SaveGameData Load()
    {
        Debug.Log("Lade Spielstand!" + GetFilename());

        SaveGameData save = XML.Load<SaveGameData>(File.ReadAllText(GetFilename()));

        Player player = Component.FindObjectOfType<Player>();
        player.transform.position = save.playerPosition;

        return save;
    }
}
