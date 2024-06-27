using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implementiert eine Gefahrenquelle, die den Spieler verletzt.
/// </summary>
public class Danger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!enabled) // wenn das Scriptinaktiv ist, nicht auf Kollision reagieren.
        {
            return;
        }

        Player p = collision.gameObject.GetComponent<Player>();
        if(p != null) // Kollision war mit Spieler.
        {
            p.LooseHealth();
        }
    }
}
