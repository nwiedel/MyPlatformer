using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : Savable
{ 
    /// <summary>
    /// Verweis auf den Animator der DoorMetal
    /// </summary>
    public Animator doorAnimator;

    /// <summary>
    /// Verweis auf den MeshRenderer der Console
    /// </summary>
    public MeshRenderer meshRenderer;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetAxisRaw("Fire1") != 0 && !doorAnimator.GetBool("isOpen"))
        {
            OpenTheDoor();
        }
    }

    private void OpenTheDoor()
    {
        doorAnimator.SetBool("isOpen", true);

        Material[] mats = meshRenderer.materials;
        Material m2 = mats[2]; // ausgeschaltetes Material
        mats[2] = mats[1];
        mats[1] = m2;
        meshRenderer.materials = mats;
    }

    protected override void saveme(SaveGameData savegame)
    {
        base.saveme(savegame);

        savegame.doorIsOpen = doorAnimator.GetBool("isOpen");
    }

    protected override void loadme(SaveGameData savegame)
    {
        base.loadme(savegame);

        Debug.Log("DoorSwitch load!");
        if (savegame.doorIsOpen)
            OpenTheDoor();
    }

    private void OnDrawGizmos()
    {
        Utils.DrawBoxCollider(this, Color.green);

    }
}
