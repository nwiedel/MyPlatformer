using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ausl�ser f�r automatischen Speicherpunkt
/// </summary>
public class SaveGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Jetzt speichern!");
        SaveGameData saveGame = new SaveGameData();
        saveGame.Save();
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
