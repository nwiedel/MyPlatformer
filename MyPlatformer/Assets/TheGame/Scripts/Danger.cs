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
        Player p = collision.gameObject.GetComponent<Player>();
        if(p != null) // Kollision war mit Spieler.
        {
            p.LooseHealth();
        }
    }
}
