using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class AIMoveState : IControlState
{
    public event Action OnCastSpell_Performed;
    
    private MoveStats _stats;
    private NavMeshAgent _agent;

    public AIMoveState(MoveStats stats, NavMeshAgent agent)
    {
        _stats = stats;
        _agent = agent;

        _agent.speed = _stats.WalkSpeed;
    }
    
    public virtual void Enter()
    {
        _agent.enabled = true;
    }

    public virtual void Exit()
    {
        _agent.enabled = false;
    }

    public virtual void Update()
    {
        _agent.SetDestination(Vector3.zero);
    }
}
