using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
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

    private void Awake()
    {
        SaveGameData.onSave += saveme;
    }

    private void saveme(SaveGameData savegame)
    {

    }

    private void OnDestroy()
    {
        SaveGameData.onSave -= saveme;
    }

    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeGameObject != this.gameObject)
        {
            Gizmos.color = Color.magenta;
            Matrix4x4 oldMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(GetComponent<BoxCollider>().center,
                GetComponent<BoxCollider>().size);
            Gizmos.matrix = oldMatrix;
        }

    }
}
