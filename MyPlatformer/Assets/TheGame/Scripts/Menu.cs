using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    /// <summary>
    /// Wahr, wenn Taste bereits zuvor als gedrückt erkannt wurde.
    /// Nötig, um Mehrfachauswertungen der Menütaste zu verhindern.
    /// </summary>
    private bool keyWasPressed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Menu") != 0)
        {
            if (!keyWasPressed)
            {
                GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
            }
            keyWasPressed = true;
        }
        else
        {
            keyWasPressed = false;
        }
    }

    /// <summary>
    /// Startet ein neues Spiel, wenn auf den Neu-Button im Menü
    /// geklickt wird.
    /// </summary>
    public void OnButtonNewPressed()
    {
        SaveGameData.current = new SaveGameData();

        LevelManager lm = FindObjectOfType<LevelManager>();
        lm.LoadScene("Scene1");

        GetComponent<Canvas>().enabled = false;
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
