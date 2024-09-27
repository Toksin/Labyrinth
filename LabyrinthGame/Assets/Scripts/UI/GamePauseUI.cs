using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] Button exitButton;
    [SerializeField] Button continueButton;

    private void Awake()
    {        
        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        continueButton.onClick.AddListener(() =>
        {
            Hide();
            Time.timeScale = 1f;
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
