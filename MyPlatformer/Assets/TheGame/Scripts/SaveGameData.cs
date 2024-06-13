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
    /// Das aktuelle SaveGame.
    /// </summary>
    public static SaveGameData current = new SaveGameData();

    /// <summary>
    /// Refgerenz der Spielerposition.
    /// </summary>
    public Vector3 playerPosition = Vector3.zero;

    /// <summary>
    /// Referenz des Zustandes der Tür.
    /// </summary>
    public bool doorIsOpen = false;

    /// <summary>
    /// Die ID des Triggers, der zuletzt das speichern ausgelöst hat.
    /// </summary>
    /// <seealso cref="SaveGameTrigger.ID"/>
    public string lastTriggerID = "";

    /// <summary>
    /// Name der Scene, in der sich die Spielfigur momentan befindet.
    /// </summary>
    public string recentScene = "";

    /// <summary>
    /// Methoden, die sich in ein SaveEvent eintragen wollen,
    /// müssen von dieser Form sein.
    /// </summary>
    /// <param name="savegame"></param>
    public delegate void SaveHandler(SaveGameData savegame);

    /// <summary>
    /// Methoden, die sich hier eintragen, werden aufgerufen,wenn
    /// Scenenobjekte ihren Zustand in den Speicherstand eintragen sollen.
    /// </summary>
    public static event SaveHandler onSave;
    /// <summary>
    /// Methoden, die sich hier eintragen, werden aufgerufen, wenn 
    /// ein Spielstand aus einer Savegame-Datei geladen wurde.
    /// Die Methoden sollten das Wiederherstellen des Objektzustandes
    /// aus dem Spielstand implementieren.
    /// </summary>
    public static event SaveHandler onLoad;

    /// <summary>
    /// liefert den Pfad und den Dateinamen der Speicherdatei,
    /// in den der Spielstand geschrieben wird.
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
        Debug.Log("Speichere Spielstand! " + GetFilename());

        if(onSave != null) 
            onSave(this);

        string xml = XML.Save(this);

        File.WriteAllText(GetFilename(), xml);
    }

    /// <summary>
    /// läd den Spielstand
    /// </summary>
    /// <returns></returns>
    public static SaveGameData Load()
    {
        if (!File.Exists(GetFilename()))
        {
            return new SaveGameData(); ;
        }

        Debug.Log("Lade Spielstand! " + GetFilename());

        SaveGameData save = XML.Load<SaveGameData>(File.ReadAllText(GetFilename()));

        if (onLoad != null)
        {
            onLoad(save);
        }
        return save;
    }
}
