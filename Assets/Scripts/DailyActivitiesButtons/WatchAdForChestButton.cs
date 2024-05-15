using System;
using EstotyHomework.DailyActivitiesComponents;
using UnityEngine;

namespace EstotyHomework.DailyActivitiesButtons
{
    public class WatchAdForChestButton : MonoBehaviour
    {
        public static WatchAdForChestButton Instance;
        [HideInInspector]
        public Chest chest;

        private void Awake()
        {
            Instance = this;
        }

        public void OnClickWatchAd()
        {
            chest.ChestUnlock();
        }
    }
}