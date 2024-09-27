using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private PlayerController playerController;
    private float footStepTimer;
    private float footStepTimerMax = .4f; 

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.IsWalking()) 
        {
            footStepTimer -= Time.deltaTime;

            if (footStepTimer <= 0f) 
            {
                footStepTimer = footStepTimerMax;
                float volume = 1f;
                SoundManager.Instance.PlayFootSounds(playerController.transform.position, volume);
            }
        }
        else
        {
            footStepTimer = 0f; 
        }
    }
}
