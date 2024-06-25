using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Zeigt die Spielergesundheit in Form eines Forschrittsbalkens an.
/// </summary>
public class HealthBar : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf die Grafik, die skaliert werden soll.
    /// </summary>
    public Image progressbar;

    /// <summary>
    /// Zeiger auf die aktuelle Spielerkomponente.
    /// </summary>
    private Player player;

    // Update is called once per frame
    private void Update()
    {
        if(player == null)
        {
            player = FindAnyObjectByType<Player>();
        }
        else
        {
            progressbar.fillAmount = player.health;
        }  
    }
}
