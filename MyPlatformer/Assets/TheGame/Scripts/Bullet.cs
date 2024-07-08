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
        Debug.Log("Rotation y: " + transform.rotation.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Die Kugel wird zertört,wenn sie irgendwo auftrift.
    }
}
