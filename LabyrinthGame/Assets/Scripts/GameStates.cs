using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public static GameStates Instance { get; private set; }

    GameData gameData;

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

    private void Update()
    {
        UpdateGameData();

        switch (state)
        {
            case State.GamePlaying:
                
                if(gameData.totalKeys >= 5)
                {
                    state = State.KeysCollected;
                }
                break;

            case State.GamePaused:
                break;

            case State.GameOver:
                break;

            case State.KeysCollected:
                KeysCollected();
                break;
            case State.GameEnd:
                Debug.Log("Win");
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

}
