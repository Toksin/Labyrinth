using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float runSpeed = 4.0f;
    [SerializeField] private float gravityValue = -9.1f;
    private Vector3 playerVelocity;
    [SerializeField] private Transform cameraTransform;

    private CharacterController characterController;
    private bool isGrounded;
    private GameInput gameInput;
    private bool isWalking;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        gameInput = GameInput.Instance;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        moveDirection = cameraTransform.forward * moveDirection.z + cameraTransform.right * moveDirection.x;
        moveDirection.y = 0f;

        float currentSpeed = gameInput.PlayerRun() ? runSpeed : moveSpeed;
        characterController.Move(moveDirection * Time.deltaTime * currentSpeed);

        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
            isWalking = true; // ��������� ����, ���� �������� ��������
        }
        else
        {
            isWalking = false; // ���� �������� �� ���������, ���� ������������
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
