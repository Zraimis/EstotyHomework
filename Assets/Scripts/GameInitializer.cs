using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Bank bankObj;


    private Bank bank;
    public void Awake()
    {
        GridManager gridManager = new GridManager();
        InstantiateBank();
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(bank);
        SceneManager.LoadScene("GameplayScene");
    }
    public void InstantiateBank()
    {
        bank = Instantiate(bankObj);
        bank.transform.SetParent(canvas.transform, false);
    }
}