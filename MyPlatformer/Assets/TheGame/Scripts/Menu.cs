using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    /// <summary>
    /// Wurzelelemnt, das das gesamte Men� ein- und ausblendet.
    /// </summary>
    public GameObject menuRoot;

    /// <summary>
    /// Wahr, wenn Taste bereits zuvor als gedr�ckt erkannt wurde.
    /// N�tig, um Mehrfachauswertungen der Men�taste zu verhindern.
    /// </summary>
    private bool keyWasPressed;

    // Start is called before the first frame update
    void Start()
    {
        menuRoot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Menu") != 0)
        {
            if (!keyWasPressed)
            {
                menuRoot.SetActive(!menuRoot.activeSelf);

                Time.timeScale = menuRoot.activeSelf ? 0f : 1f; // k�rzer f�r unten
                //if (canvas.enabled)
                //{
                //    Time.timeScale = 0f;
                //}
                //else
                //{
                //    Time.timeScale = 1f;
                //}
            }
            keyWasPressed = true;
        }
        else
        {
            keyWasPressed = false;
        }
    }

    /// <summary>
    /// Startet ein neues Spiel, wenn auf den Neu-Button im Men�
    /// geklickt wird.
    /// </summary>
    public void OnButtonNewPressed()
    {
        SaveGameData.current = new SaveGameData();

        LevelManager lm = FindObjectOfType<LevelManager>();
        lm.LoadScene("Scene1");

        menuRoot.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Beendet das Spiel, wenn der Beenden-Button im Menu geklickt wird.
    /// </summary>
    public void OnButtonQuitPressed()
    {
        Debug.Log("Spiel beenden....!");
        Application.Quit();
    }
}
