using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class HealthOrb : Savable
{
    public string ID = "";

    protected override void Start()
    {
        base.Start();

        if(ID == "")
        {
            Debug.Log("Die HealthOrb " + gameObject.name + " hat keine ID bekommen!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            player.health += 0.25f;
            gameObject.SetActive(false);
        }
    }

    protected override void saveme(SaveGameData savegame)
    {
        base.saveme(savegame);

        if (!gameObject.activeSelf && !savegame.disabledHealthOrbs.Contains(ID))
        {
            savegame.disabledHealthOrbs.Add(ID);
        }
    }

    protected override void loadme(SaveGameData savegame)
    {
        base.loadme(savegame);

        if (savegame.disabledHealthOrbs.Contains(ID))
        {
            gameObject.SetActive(false);
        }
    }
}
