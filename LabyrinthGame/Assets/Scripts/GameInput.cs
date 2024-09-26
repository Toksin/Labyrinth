using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput _instance;

    public static GameInput Instance
    {
        get 
        { 
            return _instance; 
        }
    }

    public event EventHandler OnInteract;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        playerInputActions = new PlayerInputActions();
        
        playerInputActions.Player.Interact.performed += Interact_performed;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 KeyInputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        KeyInputVector = KeyInputVector.normalized;
        return KeyInputVector;
    }

    public Vector2 GetMouseDelta()
    {
        Vector2 mouseInputVector = playerInputActions.Player.Look.ReadValue<Vector2>();
        return mouseInputVector;
    }

    public bool PlayerJumped()
    {
        return playerInputActions.Player.Jump.triggered;
    }

    public bool PlayerRun()
    {
        return playerInputActions.Player.Run.ReadValue<float>() > 0;
    }
}
