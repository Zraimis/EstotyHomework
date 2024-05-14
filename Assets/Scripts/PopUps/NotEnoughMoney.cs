using UnityEngine;

namespace EstotyHomework.PopUps
{
    // TODO consider better naming i.e. NotEnoughMoneyPopup 
    public class NotEnoughMoney : MonoBehaviour
    {
        public void OnClickDestroyPopUp()
        {
            Destroy(gameObject);
        }
    }
}