using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class timerOven : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    public int duration;
    private int remainingDuration;
    public GameObject timer;

    public Color midcolor = Color.yellow;
    public Color endcolor = Color.red;
    public Color startcolor = Color.green;
    void Start()
    {
        begin(duration);
    }
    private void begin(int second)
    {
        remainingDuration = second;
        StartCoroutine(updatetimer());
    }
    private IEnumerator updatetimer()
    {
        while (remainingDuration >= 0)
        {
            uiFill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            Updatecolor();
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        onEnd();
    }
    private void Updatecolor()
    {
        float progress = Mathf.InverseLerp(0, duration, remainingDuration);
        if (progress < 1f && progress>0.5f)
        {
            uiFill.color = startcolor;
        }
        else if (progress > 0.25f && progress < 0.5f)
        {
            uiFill.color = midcolor;    
        }
        else if(progress <0.25f)
        {
         
            uiFill.color = endcolor;
        }
    }
    private void onEnd()
    {
        timer.SetActive(false);
    }
}
  
