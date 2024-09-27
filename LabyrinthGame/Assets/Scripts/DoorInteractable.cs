using UnityEngine;

public class DoorInteractable : MonoBehaviour
{ 
        
    public void Interact()
    {
        if(!GameStates.Instance.KeysCollected())
        {            
        }
        else
        {
            GameStates.Instance.GameWin();
        }
    }
}
