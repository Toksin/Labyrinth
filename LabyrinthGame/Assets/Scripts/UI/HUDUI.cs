using TMPro;
using UnityEngine;


public class HUDUI : MonoBehaviour
{
    GameData gameData;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI keysAmount;
    [SerializeField] TimeTracker timeTracker;
   
    void Update()
    {
        gameData = SaveSystem.Load();
        UpdateHUDUI();
    }

    private void UpdateHUDUI()
    {
        time.text = $"Time: {timeTracker.HowMuchTimeSpend():F2} seconds";
        keysAmount.text = $"Keys {gameData.totalKeys} / 5";
    }
}
