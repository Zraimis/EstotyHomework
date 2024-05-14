using UnityEngine;

namespace EstotyHomework.DailyActivitiesComponents
{
    public class ProgressBar
    {
        public static ProgressBar Instance { get; private set; }
        public ProgressBar()
        {
            if (Instance != null && Instance != this)
            {
                return;
            }
            else
            {
                Instance = this;
            }
        }
        [HideInInspector]
        public int _activityPointsToGet;
        private float _increaseProcent;
        private float _increase;
        private float _ap;
        public void ResetProgessBar()
        {
            ProgressBar_UI.Instance.currentActivityPoints = 0;
            ProgressBar_UI.Instance.ResetProgressBarUI();           
        }

        public void UpdateProgressBar(Chest chest, int activityPoints)
        {
            _ap = activityPoints;
            _increaseProcent = _ap / _activityPointsToGet;
            _increase = 450 * _increaseProcent;
            ProgressBar_UI.Instance._currentSize += _increase;         
            ProgressBar_UI.Instance.currentActivityPoints += activityPoints;
            ProgressBar_UI.Instance.UpdateProgressBarUI();
            if (ProgressBar_UI.Instance._currentSize >= 0f)
            {
                ResetProgessBar();
                chest.ChestUnlock();
            }
        }
    }
}