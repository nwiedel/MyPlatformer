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

    private IEnumerator PerformFading(float toAlpha, bool revertToSaveGame)
    {
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
    public void FadeIn(bool revertToSaveGame)
    {
        StartCoroutine(PerformFading(0f, revertToSaveGame));
    }

    /// <summary>
    /// Blendet die Scene aus.
    /// </summary>
    /// <param name="revertToSaveGame"> Wenn true, wird nach dem Überblenden der letzte Spielstand geladen</param> 
    public void FadeOut(bool revertToSaveGame)
    {
        StartCoroutine(PerformFading(1f, revertToSaveGame));
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
