using UnityEngine;

public class SpawnNotEnoughMoneyPopUp : MonoBehaviour
{
    public static SpawnNotEnoughMoneyPopUp Instance { get; private set; }

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

    [SerializeField] 
    private NotEnoughMoney popUp;
    public void SpawnPopUp()
    {
        NotEnoughMoney s = Instantiate(popUp);
        s.transform.SetParent(transform, false);     
    }
}