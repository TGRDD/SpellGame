using UnityEngine;

[RequireComponent(typeof(MovementComponentsStorage), typeof(ControllableHandler))]
public class ControlStateStorage : MonoBehaviour
{
    [SerializeField, HideInInspector] private MovementComponentsStorage _moveComponentsStorage;
    [SerializeField, HideInInspector] private ControllableHandler _controllableHandler; 

    [SerializeField] private MoveStats moveStats;

    [Space(20f)]
    [SerializeField] private ControlStateType defaultControlState;


    public IControlState PlayerMoveState { get; private set; }
    public IControlState IdleMoveState { get; private set; }
    public IControlState AIMoveState { get; private set; }

    private void OnValidate()
    {
        _moveComponentsStorage ??= GetComponent<MovementComponentsStorage>();
        _controllableHandler ??= GetComponent<ControllableHandler>();
    }

    private void Start()
    {
        Construct();

        _controllableHandler.ChangeState(SelectDefault());
    }

    public void Construct()
    {
        PlayerMoveState = MoveStateFactory.CreatePlayerMoveState(_moveComponentsStorage.characterController, moveStats, Camera.main);
        AIMoveState = MoveStateFactory.CreateAIMoveState(moveStats, _moveComponentsStorage.navMeshAgent);
        IdleMoveState = MoveStateFactory.CreateIdleMoveState();
    }

    
    public IControlState SelectDefault()
    {
        switch (defaultControlState)
        {
            case ControlStateType.PlayerMoveState:
                return PlayerMoveState;

            case ControlStateType.IdleMoveState: 
                return IdleMoveState;

            case ControlStateType.AIMoveState:
                return AIMoveState;

            default: return IdleMoveState;
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Debug_changeState")]
    public void ChangeState()
    {
        _controllableHandler.ChangeState(SelectDefault());
    }
#endif
}

public enum ControlStateType
{
    IdleMoveState,
    PlayerMoveState,
    AIMoveState,
}