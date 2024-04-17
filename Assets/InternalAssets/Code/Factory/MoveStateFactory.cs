using UnityEngine;

public static class MoveStateFactory
{
    public static IMoveState CreatePlayerMoveState(CharacterController characterController)
    {
        return new PlayerMoveState(characterController);
    }


}

