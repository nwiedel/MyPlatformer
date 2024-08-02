using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis-Skript für alle Dinge, die mit der Pistole abgeschossen werden können
/// </summary>
public class BulletCatcher : MonoBehaviour
{
    public virtual void OnHitBullet()
    {
        Debug.Log(gameObject.name + " wurde von einer Kugel getroffen.");
    }
}
