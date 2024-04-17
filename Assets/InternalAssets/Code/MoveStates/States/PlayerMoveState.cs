using UnityEngine;

public class PlayerMoveState : IMoveState
{
    private CharacterController _characterController;

    public PlayerMoveState(CharacterController characterController)
    {
        _characterController = characterController;
    }

    public void Enter()
    {
        _characterController.enabled = true;
    }

    public void Exit()
    {
        _characterController.enabled = false;
    }

    public void Update()
    {

    }
}
