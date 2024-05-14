using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnClickResetAll : MonoBehaviour
{
    [SerializeField]
    private SpawnCards spawnCards;
    [SerializeField]
    private TMP_Text costAmount;
    [SerializeField]
    private Image backGround;
    [SerializeField]
    private GameObject moneyIcon;
    [SerializeField]
    private TimerReset timer;
    private int _costAmountInt;
    private bool _isFree = true;

    public void Awake()
    {
        if (PlayerPrefs.GetInt("freeOrBuyable") == 0)
        {
            SetFree();
        }
        else
        {
            SetFalse();
        }
    }
    public void Update()
    {
        SetFreeOrBuyable();
    }

    public bool IsFree()
    {
        return _isFree ? true : false;
    }

    public void SetFree()
    {
        _isFree = true;
    }
    public void SetFalse()
    {
        _isFree = false;
    }

    public void OnClickReset()
    {
        _costAmountInt = 10;
        if (_isFree)
        {
            _isFree = false;
            timer.ResetTimer();
            spawnCards.ResetCards();
        }
        else if (Bank.Instance.RemoveMoney(_costAmountInt))
        {
            spawnCards.ResetCards();
        }
        else
        {
            SpawnNotEnoughMoneyPopUp.Instance.SpawnPopUp();
        }
    }
    public void SetFreeOrBuyable()
    {
        if (_isFree)
        {
            costAmount.text = "Free";
            costAmount.transform.localPosition = new Vector3(-40f, 10f, 0f);
            backGround.color = new Color(0.05f, 0.7f, 0.35f);
            moneyIcon.SetActive(false);
            PlayerPrefs.SetInt("freeOrBuyable", 0);
        }
        else
        {
            moneyIcon.SetActive(true);
            costAmount.text = "10";
            costAmount.transform.localPosition = new Vector3(35f, 10f, 0f);
            backGround.color = Color.yellow;
            PlayerPrefs.SetInt("freeOrBuyable", 1);
        }
    }
}