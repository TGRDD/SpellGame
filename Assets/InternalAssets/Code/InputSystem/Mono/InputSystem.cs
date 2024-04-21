using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private void OnValidate()
    {
        _playerInput ??= FindObjectOfType<PlayerInput>();
    }


}
