using System;
using TMPro;
using UnityEngine;

public class TimerReset : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private OnClickResetAll resetActivities;
    [SerializeField] private GameObject timer;
    private float startTime = 10f;
    private float timerTime;
    private float hours;
    private float minutes;
    private float seconds;
    void Start()
    {
        if (resetActivities.IsFree())
        {
            timer.SetActive(false);
        }
        else 
        {
            timerTime = PlayerPrefs.GetFloat("timerTime"); 
        }
        

    }
    void Update()
    {
        if (timerTime < 0f) 
        {
            
            resetActivities.SetFree();
            timer.SetActive(false);
            
        }
        else
        {
            timerTime -= Time.deltaTime;
            hours = TimeSpan.FromSeconds(timerTime).Hours; 
            minutes = TimeSpan.FromSeconds(timerTime).Minutes; 
            seconds = TimeSpan.FromSeconds(timerTime).Seconds;

            timerText.text = $"New activities in: {hours}h{minutes}m{seconds}s";
            PlayerPrefs.SetFloat("timerTime",timerTime);
        }       
    }
    public void ResetTimer()
    {
        timer.SetActive(true);
        timerTime = startTime;
    }
}
