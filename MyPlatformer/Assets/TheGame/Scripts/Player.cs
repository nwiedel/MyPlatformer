using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Steuerung der Spielfigur
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// Laufgeschwindigkeit des Players
    /// </summary>
    public float speed = 0.05f;

    /// <summary>
    /// Das grafische Modell, u.a. für die Drehung in Laufrichtung
    /// </summary>
    public GameObject model;

    // Update is called once per frame
    private void Update()
    {
        // Bewegung
        transform.position += Input.GetAxis("Horizontal") * speed * transform.forward;

        // Rotation
        if (Input.GetAxis("Horizontal") > 0)
            model.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if(Input.GetAxis("Horizontal") < 0)
            model.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
}
