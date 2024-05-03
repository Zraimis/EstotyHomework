using UnityEngine;

public class NotEnoughMoney : MonoBehaviour 
{  
    public static NotEnoughMoney Instance { get; private set; }

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
    [SerializeField] private GameObject popUp;

    public void PopUpPopUp()
    {
        popUp.SetActive(true);
    }

    public void OnClickDisablePopUp()
    {
        popUp.SetActive(false);
    }
}