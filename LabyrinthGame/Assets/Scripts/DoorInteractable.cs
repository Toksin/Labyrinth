using UnityEngine;

public class DoorInteractable : MonoBehaviour
{ 
        
    public void Interact()
    {
        if(!GameStates.Instance.KeysCollected())
        {
            Debug.Log("find 5 keys");
        }
        else
        {
            GameStates.Instance.GameWin();
        }


    }
}
