using UnityEngine;

public class NotEnoughMoney : MonoBehaviour 
{
    [SerializeField] private GameObject popUp;
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
    public void PopUpPopUp()
    {
        popUp.SetActive(true);
    }

    public void OnClickDisablePopUp()
    {
        popUp.SetActive(false);
    }

}