using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioClipRefsSO AudioClipRefsSO;
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;                 
            
        }
        
    }

    private void Start()
    {
        SubscribeToEvents();       
    }     

    private void SubscribeToEvents()
    {    

        GameInput.Instance.OnInteract += GameInput_OnInteract;
        Trap.Instance.OnTrapActivate += Trap_OnTrapActivate;
    }

    private void Trap_OnTrapActivate(object sender, System.EventArgs e)
    {
        PlaySound(AudioClipRefsSO.activateTrap, mainCamera.transform.position);
    }

    private void GameInput_OnInteract(object sender, System.EventArgs e)
    {
        PlaySound(AudioClipRefsSO.collectKey, mainCamera.transform.position);
    }
  
    private float volume = 1f;

    private void PlaySound(AudioClip audioClip, Vector2 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector2 position, float volumeMultiplier = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volumeMultiplier * volume);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier);
    }
    public void ChangeVolume()
    {
        volume += .1f;
        if (volume > 1f)
        {
            volume = 0f;
        }
    }
    public float GetVolume()
    {
        return volume;
    }

    public void PlayFootSounds(Vector3 position, float volume)
    {
        PlaySound(AudioClipRefsSO.move, position, volume);
    }

}
