using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinUI : MonoBehaviour
{
    public static GameWinUI Instance;
    GameData gameData;

    [SerializeField] Button exitButton;
    [SerializeField] Button restartButton;
    [SerializeField] TextMeshProUGUI endingGameTime;
    [SerializeField] TimeTracker timeTracker;

    private void Awake()
    {
        Instance = this;

        gameData = SaveSystem.Load();
        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        restartButton.onClick.AddListener(() =>
        {
            gameData.totalKeys = 0;
            SaveSystem.Save(gameData);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

    
   

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
