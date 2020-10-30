using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainEvents : MonoBehaviour
{  
    //Corountine to hide cursor
    private Coroutine co_HideCursor;

    //pause menu panel
    public GameObject pausePanel;

    private void Start()
    {   
        // A simple way to cheese a bug i keep running into, just ignore this
        Time.timeScale = 1;

        //PAUSE MENU IS DEFAULT DISABLED
        pausePanel.SetActive(false);

        Cursor.visible = true;
    }

    void Update()
    {
        //hide cursor corountine
        if (Input.GetAxis("Mouse X") == 0 && (Input.GetAxis("Mouse Y") == 0))
        {
            if (co_HideCursor == null)
            {
                co_HideCursor = StartCoroutine(HideCursor());
            }
        }
        else
        {
            if (co_HideCursor != null)
            {
                StopCoroutine(co_HideCursor);
                co_HideCursor = null;
                Cursor.visible = true;
            }
        }

        //Pause game when escape is pressed and pause panel isnt already active. If active then continue game (both with their own class thingy)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }
        }
    }

    //Hiding Cursor
    private IEnumerator HideCursor()
    {
        yield return new WaitForSeconds(3);
        Cursor.visible = false;
    }

    //relating to the pause game
    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    // has to be public so i link the 'back' button to it
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
   
    // for main menu button in settings/pause menu
    public void MainMenuReturn()
    {
        SceneManager.LoadScene(0);
    }
}
