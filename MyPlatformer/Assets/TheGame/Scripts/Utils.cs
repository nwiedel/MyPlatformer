using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    /// <summary>
    /// Zeichnet den Box-Collider
    /// </summary>
    /// <param name="mb">MonoBehaviour, dass einen Boxcollider als Geschwister Komponente hat.</param
    /// <param name= "color">Farbe des Gismos</param>
    public static void DrawBoxCollider(MonoBehaviour mb, Color color)
    {
        if (UnityEditor.Selection.activeGameObject != mb.gameObject)
        {
            BoxCollider bc = mb.GetComponent<BoxCollider>();
            if (bc == null)
            {
                return;
            }

            Gizmos.color = color;
            Matrix4x4 oldMatrix = Gizmos.matrix;
            Gizmos.matrix = mb.transform.localToWorldMatrix;
            Gizmos.DrawWireCube(bc.center, bc.size);
            Gizmos.matrix = oldMatrix;
        }
    }
}
