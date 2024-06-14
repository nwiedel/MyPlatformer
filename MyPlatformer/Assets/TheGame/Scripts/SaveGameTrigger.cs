using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ausl�ser f�r automatischen Speicherpunkt
/// </summary>
public class SaveGameTrigger : MonoBehaviour
{
    /// <summary>
    /// Die Speicher-ID f�r den Trigger, die verhindert, dass
    /// ein Trigger mehrmals nacheinander ausl�st.
    /// </summary>
    public string ID = "";

    private void OnTriggerEnter(Collider other)
    {
        SaveGameData saveGame = SaveGameData.current;

        if(saveGame.lastTriggerID != ID)
        {
            Debug.Log("Jetzt speichern!");
            saveGame.lastTriggerID = ID;
            saveGame.Save();
        }
        else
        {
            Debug.Log("Dieser Speicherpunkt hat bereits zuletzt gespeichert.");
        }
    }

    private void OnDrawGizmos()
    {
        Utils.DrawBoxCollider(this, Color.magenta);
    }
}
