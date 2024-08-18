using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text scoretext;
    public int scorecount;

    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoretext.text = "Customers: " + Mathf.Round(scorecount);
        Debug.Log("Score updated: " + scorecount);
    }

    public void scoreIncrease() {
        scorecount++;
    }

    public int GetScore()
    {
         Debug.Log("Score retrieved: " + scorecount);
        return scorecount;
       
    }
}

