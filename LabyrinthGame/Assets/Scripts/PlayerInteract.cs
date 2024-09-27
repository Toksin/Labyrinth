using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance { get; private set; }

    [SerializeField] private float interactRange = 2f;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameInput.Instance.OnInteract += GameInput_OnInteract;
    }
    private void GameInput_OnInteract(object sender, EventArgs e)
    {
        Collider[] colliderArea = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArea)
        {
           if(collider.TryGetComponent(out KeyInteractable keyInteractable))
           {               
                keyInteractable.Interact();               
            }

           if(collider.TryGetComponent(out DoorInteractable doorInteractable))
           {               
                doorInteractable.Interact();
           }
        }
    }

    public (KeyInteractable, DoorInteractable) GetInteractableObject()
    {
        Collider[] colliderArea = Physics.OverlapSphere(transform.position, interactRange);

        KeyInteractable keyInteractable = null;
        DoorInteractable doorInteractable = null;

        foreach (Collider collider in colliderArea)
        {
            if (collider.TryGetComponent(out KeyInteractable key))
            {
                keyInteractable = key;                
            }

            if (collider.TryGetComponent(out DoorInteractable door))
            {
                doorInteractable = door;
            }
        }

        return (keyInteractable, doorInteractable);
    }
}
