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
    /// Der Multiplikator für die Sprungkraft.
    /// </summary>
    public float jumpPush = 4f;

    /// <summary>
    /// Verstärkung der Gravitation, damit die Figur schneller fällt.
    /// </summary>
    private float extraGravity = -2f;

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

    /// <summary>
    /// Ist die Figur gerade auf dem Boden?
    /// Wenn false, fällt oder sprigt sie.
    /// </summary>
    private bool onGround = false;

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

        // Springen
        RaycastHit hitInfo;
        onGround = Physics.Raycast(transform.position + (Vector3.up * 0.1f),
            Vector3.down,
            out hitInfo,
            0.12f);
        if (Input.GetAxis("Jump") > 0 && onGround)
        {
            Vector3 power = rb.velocity;
            power.y = jumpPush;
            rb.velocity = power;
        }
        rb.AddForce(new Vector3(0f, extraGravity, 0f));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Vector3 rayStartPosition = transform.position + (Vector3.up * 0.1f);
        Gizmos.DrawLine(rayStartPosition, rayStartPosition + Vector3.down * 0.12f);
    }
}
