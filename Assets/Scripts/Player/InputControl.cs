using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Player
{
    public class InputControl : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        private PlayerInputActions _playerInputAction;
        void Start()
        {
            _playerInputAction = new PlayerInputActions();
            _playerInputAction.Running.Enable();
            _playerInputAction.Running.Right.performed += Right_performed;
            _playerInputAction.Running.Left.performed += Left_performed;
            _playerInputAction.Running.Jump.performed += Jump_performed;
        }

        private void Jump_performed(InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        private void Left_performed(InputAction.CallbackContext obj)
        {
            _playerMovement.ChangeLane(false);
        }

        private void Right_performed(InputAction.CallbackContext obj)
        {
            _playerMovement.ChangeLane(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
