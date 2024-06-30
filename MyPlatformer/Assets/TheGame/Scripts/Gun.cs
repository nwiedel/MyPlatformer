using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Imolementiert das Verhalten der Pistole
/// </summary>
public class Gun : MonoBehaviour
{
    /// <summary>
    /// Lichtquelle 
    /// </summary>
    private Light fireLight;

    /// <summary>
    /// vorheriger Schus schon vollständig verarbeitet.
    /// </summary>
    private bool shotDone = true;

    /// <summary>
    /// Original Kuel, die dupliziert in die Scene geschossen wird.
    /// </summary>
    public GameObject bulletPrototype;

    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        fireLight = GetComponentInChildren<Light>();
        fireLight.enabled = false;
        playerAnim = GetComponentInParent<Animator>();

        bulletPrototype.SetActive(false);
    }

    /// <summary>
    /// Feuert einen Schuß aus der Pistole ab.
    /// </summary>
    public void Shoot()
    {
        if (shotDone)
        {
            StartCoroutine(doShoot());
        }
    }

    /// <summary>
    /// Regelt die Schuss-Ausführung
    /// </summary>
    /// <returns>IEnummerator</returns>
    private IEnumerator doShoot()
    {
        shotDone = false;

        GameObject bullet = Instantiate(bulletPrototype, bulletPrototype.transform.parent);
        bullet.transform.parent = null;

        bullet.SetActive(true);

        playerAnim.SetTrigger("gunShot");
        fireLight.enabled = true;
        yield return new WaitForSeconds(0.1f);
        fireLight.enabled = false;
        
        shotDone = true;
    }
}
