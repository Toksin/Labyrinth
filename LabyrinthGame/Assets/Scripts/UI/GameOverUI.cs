using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;
    GameData gameData;

    [SerializeField] Button exitButton;
    [SerializeField] Button restartButton;

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
