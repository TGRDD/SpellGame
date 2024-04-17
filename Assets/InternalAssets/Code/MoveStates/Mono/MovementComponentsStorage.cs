using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController), typeof(NavMeshAgent))]
public class MovementComponentsStorage : MonoBehaviour
{
    [SerializeField, HideInInspector] public CharacterController characterController { get; private set; }
    [SerializeField, HideInInspector] public NavMeshAgent navMeshAgent { get; private set; }

    private void OnValidate()
    {
        characterController ??= GetComponent<CharacterController>();
        navMeshAgent ??= GetComponent<NavMeshAgent>();
    }

    public void DisableAllComponents()
    {
        characterController.enabled = false;
        navMeshAgent.enabled = false;
    }
}
