using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.Timeline;
using Unity.VisualScripting;

/// <summary>
/// Steuerung der Spielfigur
/// </summary>
public class Player : Savable
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
    /// Zeiger auf die Animationskomponente der Spielfigur.
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Ist die Figur gerade auf dem Boden?
    /// Wenn false, fällt oder sprigt sie.
    /// </summary>
    private bool onGround = false;

    /// <summary>
    /// Das Ziel, das die Kamera verfolgt.
    /// Normalerweise ist das der Hüftknochen.
    /// </summary>
    public GameObject cameraTarget;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        base.Start();

        SetRagdollMode(false);
    }

    /// <summary>
    /// Aktiviert oder deaktiviert die Gliederpuppen-Simulation.
    /// </summary>
    /// <param name="isDead">Wenn true, dann ist Ragdoll aktiv, sonst der interaktive Spielmodus</param>
    private void SetRagdollMode(bool isDead)
    {
        // 1st!
        foreach(Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = isDead;
        }
        foreach(Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = !isDead;
        }

        // 2nd!
        GetComponent<Rigidbody>().isKinematic = isDead;
        GetComponent<Collider>().enabled = !isDead;
        GetComponentInChildren<Animator>().enabled = !isDead;

        if (isDead)
        {
            ScreenFader sf = FindObjectOfType<ScreenFader>();
            sf.FadeOut(true, 2f);

            CinemachineVirtualCamera cvc = FindObjectOfType<CinemachineVirtualCamera>();
            if (cvc != null)
            {
                cvc.Follow = null;
                cvc.LookAt = null;
            }

            enabled = false;
        }
    }

    /// <summary>
    /// Lässt die Spilfigur sterben.
    /// </summary>
    public void LooseHealth()
    {
        SetRagdollMode(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.y < -2f) // wenn der Spieler runterfällt -> sterben
        {
            LooseHealth();
            return;
        }

        // wenn im Menü, dann update abbrechen.
        if (Time.timeScale == 0f)
        {
            return;
        }

        // Speichert den Input
        float horizontalInput = Input.GetAxis("Horizontal");
        anim.SetFloat("forward", Mathf.Abs(horizontalInput));

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
            0.25f);

        if(onGround && Vector3.Angle(Vector3.up, hitInfo.normal) > 10) // rutscht
        {
            rb.AddForce(hitInfo.normal);
        }

        anim.SetBool("grounded", onGround);
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

    protected override void Awake()
    {
        base.Awake();
    
        CinemachineVirtualCamera cvc = FindObjectOfType<CinemachineVirtualCamera>();
        if (cvc != null)
        {
            cvc.Follow = transform;
            cvc.LookAt = cameraTarget.transform;
        }
    }

    protected override void saveme(SaveGameData savegame)
    {
        base.saveme(savegame);

        savegame.playerPosition = transform.position;
        savegame.recentScene = gameObject.scene.name;
    }

    protected override void loadme(SaveGameData savegame)
    {
        base.loadme(savegame);

        // Nur wenn die geladeneScene die ist, in der zuletzt gespeichert wurde....
        if(savegame.recentScene == gameObject.scene.name)
        {
            // .... dann stelle die gespeicherte Spielerposition wieder her.
            transform.position = savegame.playerPosition;
        }
    }
}
