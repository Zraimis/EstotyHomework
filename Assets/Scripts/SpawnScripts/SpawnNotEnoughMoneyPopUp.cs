using EstotyHomework.PopUps;
using UnityEngine;

namespace EstotyHomework.SpawnScripts
{
    public class SpawnNotEnoughMoneyPopUp : MonoBehaviour
    {
        public static SpawnNotEnoughMoneyPopUp Instance { get; private set; }
        [SerializeField]
        private NotEnoughMoney popUp;
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


        public void SpawnPopUp()
        {
            NotEnoughMoney s = Instantiate(popUp);
            s.transform.SetParent(transform, false);
        }
    }
}