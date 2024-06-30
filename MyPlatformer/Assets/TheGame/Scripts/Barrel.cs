using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Savable
{
    public string ID = "";

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

        if(ID == "")
        {
            Debug.LogWarning("Das Fass " + gameObject + " braucht noch eine ID.");
        } 
    }

    private void Update()
    {
        if (loadingComplete && rb.velocity.magnitude < 0.1f) // wenn geladen + Fass gestoppt
        {
            GetComponent<Danger>().enabled = false;
            this.enabled = false;
        }
    }

    protected override void saveme(SaveGameData savegame)
    {
        base.saveme(savegame);

        SaveGameData.BarrelData data = savegame.FindBarrelDataByID(ID);
        if(data == null)
        {
            data = new SaveGameData.BarrelData();
            savegame.barrelData.Add(data);
        }
        data.ID = ID;
        data.position = transform.position;
    }

    protected override void loadme(SaveGameData savegame)
    {
        base.loadme(savegame);

        SaveGameData.BarrelData data = savegame.FindBarrelDataByID(ID);
        if(data != null) // wenn gespeicherter Wert vorhanden
        {
            transform.position = data.position;
        }
        loadingComplete = true;
    }
}
