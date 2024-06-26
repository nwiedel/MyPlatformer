using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Auslöser für automatischen Speicherpunkt
/// </summary>
public class SaveGameTrigger : MonoBehaviour
{
    /// <summary>
    /// Die Speicher-ID für den Trigger, die verhindert, dass
    /// ein Trigger mehrmals nacheinander auslöst.
    /// </summary>
    public string ID = "";

    private void OnTriggerEnter(Collider other)
    {
        SaveGameData saveGame = SaveGameData.current;

        Player p = other.gameObject.GetComponent<Player>();
        if(p == null) // kein Spieler
        {
            // Kollision mit anderem Objekt als Spieler ignorieren
            return;
        }

        else if(p.health <= 0F) // Spieler schon Tod
        {
            Debug.Log("Der Spieler hat keine Lebenspunkte mehr. Nicht speichern.");
        }

        else if(saveGame.lastTriggerID == ID) // hier schon mal gespeichert
        {
            Debug.Log("Dieser Speicherpunkt hat bereits zuletzt gespeichert.");
        }
        else // wenn nichts dagegen spricht, speichern.
        {
            Debug.Log("Jetzt speichern!");
            saveGame.lastTriggerID = ID;
            saveGame.Save();
        }
    }

    private void OnDrawGizmos()
    {
        Utils.DrawBoxCollider(this, Color.magenta);
    }
}
