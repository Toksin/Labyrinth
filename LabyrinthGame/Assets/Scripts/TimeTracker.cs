using TMPro;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    private float timeSpent; 
    private bool isTiming; 
    [SerializeField] private TextMeshProUGUI timerText; 

    private void Start()
    {
        timeSpent = 0f;
        isTiming = false;
        UpdateTimerWinUI();
    }

    private void Update()
    {
        if (isTiming)
        {
            timeSpent += Time.deltaTime;
            UpdateTimerWinUI();
        }
    }

    public void StartTiming()
    {
        isTiming = true;
    }
    
    public void StopTiming()
    {
        isTiming = false;      
        
    }   
    private void UpdateTimerWinUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time: {timeSpent:F2} seconds"; 
        }
    }

    public float HowMuchTimeSpend()
    {
        return timeSpent;
    }
}
