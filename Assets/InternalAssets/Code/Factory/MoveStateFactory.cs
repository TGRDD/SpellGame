using UnityEngine;

public static class MoveStateFactory
{
    public static IControllState CreatePlayerMoveState(CharacterController characterController, MoveStats stats, Camera playerCamera)
    {
        return new PlayerMoveState(characterController, stats, playerCamera.transform);
    }


}

