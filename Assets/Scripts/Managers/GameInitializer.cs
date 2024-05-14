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
        // TODO unused references 
        GridManager gridManager = new GridManager();
        ProgressBar progressBar = new ProgressBar();
        InstantiateBank();
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(eventSystem);
        DontDestroyOnLoad(cameraUI);
        // TODO Should be constant or scene reference
        SceneManager.LoadScene("GameplayScene");
    }
    private void Update()
    {
        // TODO Why this is in update?
        StorePopup.Instance.spawnLocation = canvas;
    }
    private void InstantiateBank()
    {
        // TODO SetParent can be combined with Instantiate
        bank = Instantiate(bankObj);
        bank.transform.SetParent(canvas.transform, false);
    }
}