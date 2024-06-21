using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Übernimmt das Ein- und Ausblenden der Scene.
/// </summary>
public class ScreenFader : MonoBehaviour
{
    /// <summary>
    /// Das Bikd, dessen Aplphawert verändert wir, um
    /// das Ein- und Ausblenden der Scene zu realisieren.
    /// </summary>
    public Image overlay;

    /// <summary>
    /// Führt das Ein- und Ausblenden des Schwarzbild durch.
    /// </summary>
    /// <param name="toAlpha">Zieltransparenz zwischen 0 und 1</param>
    /// <param name="revertToSaveGame">wenn tru, wird nach dem Überblenden der letzte Spielstand geladen.</param>
    /// <param name="delay">Anzahl der Sekunden, die gewartet werden soll, bevor das Überblenden startet.</param>
    /// <returns></returns>
    private IEnumerator PerformFading(float toAlpha, bool revertToSaveGame,
        float delay)
    {
        if(delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }
        overlay.CrossFadeAlpha(toAlpha, 1f, false);

        yield return new WaitForSeconds(1f);

        if (revertToSaveGame)
        {
            SaveGameData.current = SaveGameData.Load();
            LevelManager lm = FindAnyObjectByType<LevelManager>();
            lm.LoadScene(SaveGameData.current.recentScene);
        } 
    }

    /// <summary>
    /// Blendet die Scene ein.
    /// </summary>
    /// <param name="revertToSaveGame"> Wenn true, wird nach dem Überblenden der letzte Spielstand geladen</param>
    public void FadeIn(bool revertToSaveGame, float delay = 0f)
    {
        StartCoroutine(PerformFading(0f, revertToSaveGame, delay));
    }

    /// <summary>
    /// Blendet die Scene aus.
    /// </summary>
    /// <param name="revertToSaveGame"> Wenn true, wird nach dem Überblenden der letzte Spielstand geladen</param> 
    public void FadeOut(bool revertToSaveGame, float delay = 0f)
    {
        StartCoroutine(PerformFading(1f, revertToSaveGame, delay));
    }

    private void Awake()
    {
        overlay.gameObject.SetActive(true);
        SceneManager.sceneLoaded += WhenLevelWasLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= WhenLevelWasLoaded;
    }

    private void WhenLevelWasLoaded(Scene scene, LoadSceneMode mode)
    {
        FadeIn(false);
    }
}
