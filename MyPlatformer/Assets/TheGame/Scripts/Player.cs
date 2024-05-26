using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Steuerung der Spielfigur
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// Laufgeschwindigkeit des Players.
    /// </summary>
    public float speed = 0.05f;

    /// <summary>
    /// Das grafische Modell, u.a. für die Drehung in Laufrichtung.
    /// </summary>
    public GameObject model;

    /// <summary>
    /// Der Winkel, zu dem sich die Figur um die eigene Achse(=Y)
    /// drehen soll.
    /// </summary>
    private float towardsY = 0f;

    /// <summary>
    /// Zeiger auf die Pysik Komponente.
    /// </summary>
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Speichert den Input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Bewegung
        transform.position += horizontalInput * speed * transform.forward;

        // Rotation
        if (horizontalInput > 0) // nach rechts gehen
            towardsY = 0f;
        else if (horizontalInput < 0) // nach links gehen
            towardsY = -180f; // - bedeutert, dass er sich in die Kamera dreht!
        // Sanfter Übergang der Drehbewegung
        model.transform.rotation = Quaternion.Lerp(
            model.transform.rotation,
            Quaternion.Euler(0f, towardsY, 0f),
            Time.deltaTime * 10f);
    }
}
