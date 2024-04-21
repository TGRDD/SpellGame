using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(NavMeshAgent))]
public class MovementComponentsStorage : MonoBehaviour
{
    [field: SerializeField] public CharacterController characterController { get; private set; }
    [field: SerializeField] public NavMeshAgent navMeshAgent { get; private set; }

    private void OnValidate()
    {
        characterController ??= GetComponent<CharacterController>();
        navMeshAgent ??= GetComponent<NavMeshAgent>();
    }

    private void Awake()
    {
        DisableAllComponents();
    }

    public void DisableAllComponents()
    {
        characterController.enabled = false;
        navMeshAgent.enabled = false;
    }
}
