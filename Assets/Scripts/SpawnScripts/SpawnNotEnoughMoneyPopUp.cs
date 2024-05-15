using EstotyHomework.PopUps;
using UnityEngine;

namespace EstotyHomework.SpawnScripts
{
    public class SpawnNotEnoughMoneyPopUp : MonoBehaviour
    {
        public static SpawnNotEnoughMoneyPopUp Instance { get; private set; }
        [SerializeField]
        private NotEnoughMoneyPopup popUp;
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
            NotEnoughMoneyPopup s = Instantiate(popUp, transform, false);
        }
    }
}