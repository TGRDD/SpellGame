using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovementComponentsStorage))]
public class ControllableHandler : MonoBehaviour
{
    public UnityEvent OnCastSpell;

    [Header("Components")]
    [SerializeField, HideInInspector] private MovementComponentsStorage _moveComponentsStorage;

    [Header("MoveState")]
    private IControllState _currentMoveState;

    public IControllState _playerMoveState { get; private set; }

    [Header("Stats")]
    [SerializeField] private MoveStats moveStats;

    //TODO: Change to instance

    private void OnValidate()
    {
        _moveComponentsStorage ??= GetComponent<MovementComponentsStorage>();
    }

    private void Start()
    {
        InizializeStates();
        ChangeState(_playerMoveState);
    }

    public void ChangeState(IControllState state)
    {
        if (_currentMoveState != null)
        {
            _currentMoveState.OnCastSpell_Performed -= CastSpell;
            _currentMoveState.Exit();
        }

        _currentMoveState = state;

        _currentMoveState.OnCastSpell_Performed += CastSpell;
        _currentMoveState.Enter();
    }

    private void Update()
    {
        if (_currentMoveState != null)
        {
            _currentMoveState.Update();
        }
    }

    private void InizializeStates()
    {
        _playerMoveState = MoveStateFactory.CreatePlayerMoveState(_moveComponentsStorage.characterController, moveStats, Camera.main);
    }

    public void CastSpell()
    {
        OnCastSpell?.Invoke();
    }
}
