using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Verhalten für die RoboterKugel.
/// </summary>
public class Trainer : BulletCatcher
{
    public override void OnHitBullet()
    {
        base.OnHitBullet();
        Debug.Log("Trainer zerstört!!!!!");
        Destroy(gameObject);
    }
}
