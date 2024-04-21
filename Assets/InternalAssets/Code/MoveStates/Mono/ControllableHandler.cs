using System;
using UnityEngine;

[RequireComponent(typeof(ControlStateStorage))]
public class ControllableHandler : MonoBehaviour
{
    public event Action<IControlState> OnStateChanged;

    private IControlState _currentMoveState;
    public void ChangeState(IControlState state)
    {
        if (_currentMoveState != null)
        {
            _currentMoveState.Exit();
        }

        _currentMoveState = state;

        _currentMoveState.Enter();
    }
    private void Update()
    {
        if (_currentMoveState != null)
        {
            _currentMoveState.Update();
        }
    }
}
