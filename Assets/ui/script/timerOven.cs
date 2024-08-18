using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerOven : MonoBehaviour
{
    public bool hasEnded = false;
    [SerializeField] private Image uiFill;
    public int duration;
    private int remainingDuration;
    public GameObject timer;

    public Color startColor = Color.green;
    public Color midColor = Color.yellow;
    public Color endColor = Color.red;

    private Coroutine timerCoroutine;

    // This method starts the timer whenever it's called
    public void StartTimer(int seconds)
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            
        }
        duration = seconds;
        remainingDuration = seconds;
        timer.SetActive(true);
        timerCoroutine = StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            uiFill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            UpdateColor();
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void UpdateColor()
    {
        float progress = Mathf.InverseLerp(0, duration, remainingDuration);
        if (progress > 0.5f)
        {
            uiFill.color = startColor;
        }
        else if (progress > 0.25f)
        {
            uiFill.color = midColor;
        }
        else
        {
            uiFill.color = endColor;
        }
    }

    private void OnEnd()
    {
        timer.SetActive(false);
    }
}
