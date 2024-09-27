using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public static Trap Instance { get; private set; }
    public event EventHandler OnTrapActivate;

    [SerializeField] private GameObject smokeEffect;
    [SerializeField] private float deathDelay = 2f;

    private string PLAYER_TAG = "Player";

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG)) 
        {
            OnTrapActivate?.Invoke(this, EventArgs.Empty);
            smokeEffect.SetActive(true);
            StartCoroutine(DieAfterDelay());
        }
    }   

    private IEnumerator DieAfterDelay()
    {
        yield return new WaitForSeconds(deathDelay);
        
        GameStates.Instance.GameOver();
    }
}
