using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int newSceneIndex;
    private int nextSceneLoad;

    public void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {   
            if(SceneManager.GetActiveScene().buildIndex == 10)
            {
                SceneManager.LoadScene(0);
            }
            else
            {

                SceneManager.LoadScene(nextSceneLoad);
                
            //Setting Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
            }


        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(newSceneIndex);
    }
}