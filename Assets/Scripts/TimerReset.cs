using System;
using TMPro;
using UnityEngine;

public class TimerReset : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private SpawnCards spawnCards;
    private float startTime = 5f;
    private float timerTime;
    void Start()
    {
        timer.text = startTime.ToString();
        timerTime = startTime;
    }
    void Update()
    {
        if (timerTime < 0f) 
        {
            spawnCards.ResetCards();
            timerTime = startTime;
        }
        else
        {
            timerTime -= Time.deltaTime;
            float hours = TimeSpan.FromSeconds(timerTime).Hours; 
            float minutes =TimeSpan.FromSeconds(timerTime).Minutes; 
            float seconds = TimeSpan.FromSeconds(timerTime).Seconds;
            timer.text = $"New activities in: {hours}h{minutes}m{seconds}s";
        }       
    }
}
