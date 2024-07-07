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
            Vector3.forward;//* (transform.rotation.y < 0f ? 5f : -5f);
        Debug.Log("Rotation y: " + transform.rotation.y);
    }
}
