using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerController _playerController;
    
    #region InputAction
    private PlayerInput _inputController;
    private InputAction _actionMove;
  
    #endregion


    private void Awake()
    {
        _inputController = GetComponent<PlayerInput>();
       _playerController = GetComponent<PlayerController>();
        
       _actionMove = _inputController.actions["Move"];

    }

    private void Update()
    {
        Moving();
    }
    
    private void Moving()
    {
        Vector2 input = _actionMove.ReadValue<Vector2>();
        _playerController.MoveInput = input;
    }
}
