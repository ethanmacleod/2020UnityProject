using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject levelSelectPanel;
    public GameObject levelSelectPanel2;

    private void Start()
    {
        settingsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        levelSelectPanel2.SetActive(false);

        //little bug fix - just ignore it
        Cursor.visible = true;
    }

    public void Playbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
