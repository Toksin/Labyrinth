using UnityEngine;

public class GameStates : MonoBehaviour
{
    public static GameStates Instance { get; private set; }

    GameData gameData;

    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private GameWinUI gameWinUI;
    [SerializeField] private TimeTracker timeTracker;
    [SerializeField] private GamePauseUI gamePauseUI;

    private bool isGamePaused = false;

  private enum State
  {
        GamePlaying,
        GamePaused,
        GameOver,
        KeysCollected,
        GameEnd
  }

    private State state;

    private void Awake()
    {
        Instance = this;
        state = State.GamePlaying;        
    }

    private void Start()
    {
        GameInput.Instance.OnPauseActivate += GameInpu_OnPauseActivate;
    }

    private void GameInpu_OnPauseActivate(object sender, System.EventArgs e)
    {
        TogglePauseGame();
    }

    private void Update()
    {
        UpdateGameData();

        switch (state)
        {
            case State.GamePlaying:

                timeTracker.StartTiming();
                if (gameData.totalKeys >= 5)
                {
                    state = State.KeysCollected;
                }
                break;

            case State.GamePaused:
                break;

            case State.GameOver:
                timeTracker.StopTiming();
                Cursor.visible = true;
                gameOverUI.Show();
                break;

            case State.KeysCollected:
                KeysCollected();
                break;
            case State.GameEnd:
                timeTracker.StopTiming();
                gameWinUI.Show();
                break;
        }
    }

    private void UpdateGameData()
    {
        gameData = SaveSystem.Load();
    }
    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool KeysCollected()
    {
        return state == State.KeysCollected;
    }
    
    public void GameWin()
    {
        state = State.GameEnd;
    }

    public void GameOver()
    {
        state = State.GameOver;
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if(isGamePaused)
        {
            gamePauseUI.Show();
            Time.timeScale = 0f;
        }
        else
        {
            gamePauseUI.Hide();
            Time.timeScale = 1f;
        }
        
    }

}
