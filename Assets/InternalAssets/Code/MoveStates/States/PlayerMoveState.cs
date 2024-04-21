using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : IControllState
{
    public event Action OnCastSpell_Performed;
    
    private CharacterController _characterController;
    private Transform cameraTransform;
    private Controls inputActions; //TODO: CHANGE TO INJECT

    private MoveStats moveStats;
    private Vector2 horizontalLookVector;
    private float _moveSpeed;

    private Transform charTransform => _characterController.gameObject.transform;
    private Vector2 movementVector => inputActions.Player.Move.ReadValue<Vector2>();
    private Vector2 lookVector => inputActions.Player.Look.ReadValue<Vector2>();
    private float sprintScale => inputActions.Player.Sprint.ReadValue<float>();
    public float MoveSpeedFixed => _moveSpeed * Time.deltaTime;
    
 

    public PlayerMoveState(CharacterController characterController, MoveStats stats, Transform cameraTransform)
    {
        _characterController = characterController;
        moveStats = stats;
        inputActions = new Controls();
        _moveSpeed = moveStats.WalkMoveSpeed;
    }

    public void Enter()
    {
        _characterController.enabled = true;
        inputActions.Enable();

        inputActions.Player.UseSpell.performed += UseSpell_Performed;
        inputActions.Player.Move.performed += OnMove_Performed;
    }

    public void Exit()
    {
        _characterController.enabled = false;

        inputActions.Player.UseSpell.performed -= UseSpell_Performed;
        inputActions.Player.Move.performed -= OnMove_Performed;
        
        inputActions.Disable();
    }

    public void Update()
    {
        Rotation();
        Movement();
        Gravity();
        Sprint();
    }

    private void UseSpell_Performed(InputAction.CallbackContext context)
    {
        OnCastSpell_Performed?.Invoke();
    }

    private void OnMove_Performed(InputAction.CallbackContext context)
    {
        MoveToDirection(context.ReadValue<Vector2>());
    }

    private void Movement()
    {
        MoveToDirection(movementVector);
    }

    private void Sprint()
    {
        _moveSpeed = sprintScale > 0 ? moveStats.RunWalkSpeed : moveStats.WalkMoveSpeed;
    }

    private void Rotation()
    {
        horizontalLookVector.y = lookVector.x;
        charTransform.Rotate(horizontalLookVector * Time.deltaTime * moveStats.RotationScale);
    }

    private void Gravity()
    {
        _characterController.Move(Vector3.down * Time.deltaTime * moveStats.GravityScale);
    }

    private void MoveToDirection(Vector2 direction)
    {
        Vector3 worldDirection = charTransform.TransformDirection(new Vector3(direction.x, 0f, direction.y));

        _characterController.Move(worldDirection * MoveSpeedFixed);
    }
}
