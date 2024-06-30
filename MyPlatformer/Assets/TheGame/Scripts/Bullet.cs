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
            Vector3.forward * (transform.rotation.y < 0f ? 0.1f : -0.1f);
        Debug.Log(transform.rotation.x + ", " 
            + transform.rotation.y  + ", "
            + transform.rotation.z);
    }
}
