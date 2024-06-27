using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Savable
{
    /// <summary>
    /// Indikator, ob das Laden des Fasses beendet ist.
    /// </summary>
    private bool loadingComplete = false;

    /// <summary>
    /// Zeiger auf die Rigidbody - Komponente.
    /// </summary>
    private Rigidbody rb;

    protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody>();
        if(loadingComplete && rb.velocity.magnitude < 0.1f) // wenn geladen + Fass gestoppt
        {
            GetComponent<Danger>().enabled = false;
            this.enabled = false;
        }
    }
    protected override void saveme(SaveGameData savegame)
    {
        base.saveme(savegame);

        savegame.barrelPosition = transform.position;
    }

    protected override void loadme(SaveGameData savegame)
    {
        base.loadme(savegame);

        if(savegame.barrelPosition != Vector3.zero)
        {
            transform.position = savegame.barrelPosition;
        }
        loadingComplete = true;
    }
}
