using EstotyHomework.DailyActivitiesComponents;
using UnityEngine;

namespace EstotyHomework.DailyActivitiesButtons
{
    public class WatchAdForChest : MonoBehaviour
    {
        [HideInInspector]
        public Chest chest;
        public void OnClickWatchAd()
        {
            chest.ChestUnlock();
        }
    }
}