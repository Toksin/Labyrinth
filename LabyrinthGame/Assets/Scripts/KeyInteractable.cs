using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : MonoBehaviour
{
    GameData gameData;

    private void Awake()
    {
        gameData = SaveSystem.Load();
    }

    public void Interact()
    {
        gameData.totalKeys += 1;
        SaveSystem.Save(gameData);
        Debug.Log(gameData.totalKeys);
    }
}
