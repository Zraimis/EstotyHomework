using EstotyHomework.DailyActivitiesButtons;
using System;
using TMPro;
using UnityEngine;

namespace EstotyHomework.DailyActivitiesComponents
{
    public class TimerReset : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text timerText;
        [SerializeField]
        private OnClickResetAll resetActivities;
        [SerializeField]
        private GameObject timer;

        private float _startTime = 100f;
        private float _timerTime;
        private float _hours;
        private float _minutes;
        private float _seconds;
        void Start()
        {
            if (resetActivities.IsFree())
            {
                timer.SetActive(false);
            }
            else
            {
                _timerTime = PlayerPrefs.GetFloat("timerTime");
            }
        }

        void Update()
        {
            if (_timerTime < 0f)
            {
                resetActivities.SetFree();
                timer.SetActive(false);
            }
            else
            {
                _timerTime -= Time.deltaTime;
                _hours = TimeSpan.FromSeconds(_timerTime).Hours;
                _minutes = TimeSpan.FromSeconds(_timerTime).Minutes;
                _seconds = TimeSpan.FromSeconds(_timerTime).Seconds;

                UpdateTimerUI();
            }
        }

        private void UpdateTimerUI()
        {
            timerText.text = $"New activities in: {_hours}h{_minutes}m{_seconds}s";
            PlayerPrefs.SetFloat("timerTime", _timerTime);
        }

        public void ResetTimer()
        {
            timer.SetActive(true);
            _timerTime = _startTime;
        }
    }
}