using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private Bank bankObj;
    [SerializeField]
    private GameObject eventSystem;
    [SerializeField]
    private Camera cameraUI;
    private Bank bank;
    public void Awake()
    {
        GridManager gridManager = new GridManager();
        ProgressBar progressBar = new ProgressBar();
        InstantiateBank();
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(eventSystem);
        DontDestroyOnLoad(cameraUI);
        SceneManager.LoadScene("GameplayScene");
    }
    private void Update()
    {
        StorePopup.Instance.spawnLocation = canvas;
    }
    private void InstantiateBank()
    {
        bank = Instantiate(bankObj);
        bank.transform.SetParent(canvas.transform, false);
    }
}