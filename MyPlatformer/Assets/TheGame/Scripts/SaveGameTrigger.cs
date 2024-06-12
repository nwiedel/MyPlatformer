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
        if(UnityEditor.Selection.activeGameObject != this.gameObject)
        {
            Gizmos.color = Color.magenta;
            Matrix4x4 oldMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(GetComponent<BoxCollider>().center,
                GetComponent<BoxCollider>().size);
            Gizmos.matrix = oldMatrix;
        }
        
    }
}
