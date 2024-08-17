using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingMenu : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    private scoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<scoreManager>();

        // Update the score text in the ending menu
        if (scoreManager != null && scoretext != null)
        {
            scoretext.text = "Customers served: " + Mathf.Round(scoreManager.scorecount);
        }
    }

    public void RetryLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene("Envirement");

        // Reset the time scale in case the game was paused
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        // Load the main menu scene by its name or index
        SceneManager.LoadScene("menu");

        // Reset the time scale in case the game was paused
        Time.timeScale = 1f;
    }
}


