using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{
    public int health = 5; // Current health of the player
    public Image[] hats; // Array of Image components representing the hats
    public Sprite fullhat; // The sprite to display when a hat is full
    public GameObject losingScreen; // Reference to the losing screen Canvas

    private int previousHealth;

    void Start()
    {
        UpdateHealthDisplay();
        previousHealth = health;
        losingScreen.SetActive(false); // Ensure the losing screen is hidden at the start
    }

    void Update()
    {
        if (health != previousHealth)
        {
            UpdateHealthDisplay();
            previousHealth = health;

            if (health <= 0)
            {
                ShowLosingScreen();
            }
        }
    }

    void UpdateHealthDisplay()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            if (i < health)
            {
                // Show the hat and set the sprite to fullhat
                hats[i].sprite = fullhat;
                Color color = hats[i].color;
                color.a = 1f; // Fully opaque
                hats[i].color = color;
            }
            else
            {
                // Hide the hat by setting its alpha to 0
                Color color = hats[i].color;
                color.a = 0f; // Fully transparent
                hats[i].color = color;
            }
        }
    }

    void ShowLosingScreen()
    {
        // Show the losing screen
        losingScreen.SetActive(true);
        // Optionally, pause the game or trigger other events here
        Time.timeScale = 0f; // Pauses the game (optional)
    }
}


