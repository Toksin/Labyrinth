using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject smokeEffect;
    [SerializeField] private float deathDelay = 2f;

    private string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG)) 
        {
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
