using UnityEngine;

[RequireComponent(typeof(MovementComponentsStorage))]
public class MovementHandler : MonoBehaviour
{
    [Header("Components")]
    [SerializeField, HideInInspector] private MovementComponentsStorage _moveComponentsStorage;

    [Header("MoveState")]
    private IMoveState _currentMoveState;

    public IMoveState _characterMoveState { get; private set; }

    private void OnValidate()
    {
        _moveComponentsStorage ??= GetComponent<MovementComponentsStorage>();
    }

    private void Start()
    {
        InizializeStates();
    }

    public void ChangeState(IMoveState state)
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
        if (_currentMoveState == null)
        {
            _currentMoveState.Update();
        }
    }

    private void InizializeStates()
    {
        _characterMoveState = MoveStateFactory.CreatePlayerMoveState(_moveComponentsStorage.characterController);
    }
}
