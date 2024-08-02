using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Steuert das Verhalten einer abgeschossenen Pistolenkugel
/// </summary>
public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = 
            Vector3.forward * (transform.rotation.z < 0f ? 5f : -5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletCatcher bc = collision.gameObject.GetComponent<BulletCatcher>();
        if(bc != null)
        {
            bc.OnHitBullet();
        }

        Destroy(gameObject); // Die Kugel wird zertört,wenn sie irgendwo auftrift.
    }
}
