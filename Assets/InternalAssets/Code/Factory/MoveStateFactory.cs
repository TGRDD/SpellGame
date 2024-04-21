using UnityEngine;
using UnityEngine.AI;

public static class MoveStateFactory
{
    public static IControlState CreatePlayerMoveState(CharacterController characterController, MoveStats stats, Camera playerCamera)
    {
        return new PlayerMoveState(characterController, stats, playerCamera.transform);
    }

    public static IControlState CreateIdleMoveState()
    {
        return new IdleMoveState();
    }

    public static IControlState CreateAIMoveState(MoveStats stats, NavMeshAgent agent)
    {
        return new AIMoveState(stats, agent);
    }

}

