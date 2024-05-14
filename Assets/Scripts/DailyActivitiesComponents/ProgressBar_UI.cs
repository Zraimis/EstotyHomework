using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EstotyHomework.DailyActivitiesComponents
{
    public class ProgressBar_UI : MonoBehaviour
    {
        public static ProgressBar_UI Instance;
        public Image progressBar;
        public TMP_Text currentActivityPointsText;
        public float _currentSize = -450;
        public int currentActivityPoints;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            currentActivityPoints = PlayerPrefs.GetInt("activityPoints");
            currentActivityPointsText.text = currentActivityPoints.ToString();
            if(PlayerPrefs.GetFloat("currentSize") == 0)
            {
                _currentSize = -450;
            }
            else
            {
                _currentSize = PlayerPrefs.GetFloat("currentSize");
            }           
            progressBar.rectTransform.offsetMax = new Vector2(_currentSize, -5);
        }

        public void UpdateProgressBarUI()
        {
            currentActivityPointsText.text = currentActivityPoints.ToString();
            progressBar.rectTransform.offsetMax = new Vector2(_currentSize, -5);
            PlayerPrefs.SetFloat("currentSize", _currentSize);
            PlayerPrefs.SetInt("activityPoints", currentActivityPoints);
        }

        public void ResetProgressBarUI()
        {
            _currentSize = -450;
            progressBar.rectTransform.offsetMax = new Vector2(_currentSize, -5);
            PlayerPrefs.SetFloat("currentSize", _currentSize);
            UpdateProgressBarUI();
        }
    }
}