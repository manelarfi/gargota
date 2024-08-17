using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backmenu : MonoBehaviour
{
    
   public static bool gamepaused = false;
    public GameObject pausemenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            if (gamepaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume() {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamepaused = false;
    }
    void pause() {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamepaused = true;  
    }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}

