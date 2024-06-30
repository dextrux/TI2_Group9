using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using static UnityEngine.Rendering.DebugUI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
namespace Player
{
    public class InputControl : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private bool _menuInput;
        [SerializeField] private bool _playingInput;
        [SerializeField] private GameObject _modelOnMenu;
        private float timer;
        private void Awake()
        {
            EnhancedTouchSupport.Enable();
        }
        private void Update()
        {
            if (_playingInput)
            {
                PlayingGame();
            }
            else if (_menuInput)
            {
                HoldOnMenu();
            }
            if (Touch.activeFingers.Count == 1)
            {
                Touch activeTouch = Touch.activeFingers[0].currentTouch;
                Debug.Log(activeTouch.delta);
            }
        }
        private void CaptureInput()
        {

        }
        private void HoldOnMenu()
        {
            if (Time.time > timer)
            {
                timer = Time.time + 0.05F;
                if (Touch.activeFingers.Count == 1)
                {
                    if (Touch.activeFingers[0].currentTouch.startScreenPosition.x > Touch.activeFingers[0].currentTouch.screenPosition.x)
                    {
                        _modelOnMenu.transform.Rotate(new Vector3(0, (_modelOnMenu.transform.rotation.y + 10), 0));
                    }
                    else if (Touch.activeFingers[0].currentTouch.startScreenPosition.x < Touch.activeFingers[0].currentTouch.screenPosition.x)
                    {
                        _modelOnMenu.transform.Rotate(new Vector3(0, (_modelOnMenu.transform.rotation.y - 10), 0));
                    }
                }
            }
        }
        private void PlayingGame()
        {
            if (Touch.activeFingers.Count == 1)
            {
                if (Touch.activeFingers[0].currentTouch.startTime - Touch.activeFingers[0].lastTouch.startTime < 0.5)
                {
                    Debug.Log("Ativação de Habilidade");
                }
                if (Touch.activeFingers[0].currentTouch.startScreenPosition.x > Touch.activeFingers[0].currentTouch.screenPosition.x)
                {
                    _playerMovement.ChangeLane(false);
                }
                else if (Touch.activeFingers[0].currentTouch.startScreenPosition.x < Touch.activeFingers[0].currentTouch.screenPosition.x)
                {
                    _playerMovement.ChangeLane(true);
                }
                else if (Touch.activeFingers[0].currentTouch.startScreenPosition.y > Touch.activeFingers[0].currentTouch.screenPosition.y)
                {
                    _playerMovement.Jump();
                }
                else if (Touch.activeFingers[0].currentTouch.startScreenPosition.y < Touch.activeFingers[0].currentTouch.screenPosition.y)
                {
                    _playerMovement.Slide();
                }
            }
        }
        public void EnableMenuMode()
        {
            _menuInput = true;
            _playingInput = false;
        }
        public void EnablePlayMode()
        {
            _menuInput = false;
            _playingInput = true;
        }
        public void ResetModelPosition()
        {
            _modelOnMenu.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
        }
    }
}