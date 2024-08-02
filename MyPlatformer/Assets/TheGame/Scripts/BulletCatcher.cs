using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis-Skript f�r alle Dinge, die mit der Pistole abgeschossen werden k�nnen
/// </summary>
public class BulletCatcher : MonoBehaviour
{
    public virtual void OnHitBullet()
    {
        Debug.Log(gameObject.name + " wurde von einer Kugel getroffen.");
    }
}
