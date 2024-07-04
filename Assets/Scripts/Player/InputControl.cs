using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
namespace Player
{
    public class InputControl : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private bool _menuInput;
        [SerializeField] private bool _playingInput;
        [SerializeField] private PlayerLife _playerLife;
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
                        //transform.Rotate(new Vector3(0, (transform.rotation.y + 10), 0));
                    }
                    else if (Touch.activeFingers[0].currentTouch.startScreenPosition.x < Touch.activeFingers[0].currentTouch.screenPosition.x)
                    {
                        //transform.Rotate(new Vector3(0, (transform.rotation.y - 10), 0));
                    }
                }
            }
        }
        private void PlayingGame()
        {
            if (Touch.activeFingers.Count == 1)
            {
                if (Touch.activeFingers[0].currentTouch.ended && Touch.activeFingers[0].currentTouch.startScreenPosition.x > Touch.activeFingers[0].currentTouch.screenPosition.x)
                {
                    _playerMovement.ChangeLane(false);
                }
                if (Touch.activeFingers[0].currentTouch.ended && Touch.activeFingers[0].currentTouch.startScreenPosition.x < Touch.activeFingers[0].currentTouch.screenPosition.x)
                {
                    _playerMovement.ChangeLane(true);
                }
            }
            if (Touch.activeTouches.Count == 5)
            {
                _playerLife.enabled = false;
            }
        }
        public void EnableMenuMode()
        {
            _menuInput = true;
            _playingInput = false;
            _playerLife.enabled = false;
        }
        public void EnablePlayMode()
        {
            _menuInput = false;
            _playingInput = true;
            _playerLife.enabled = true;
        }
        public void ResetModelPosition()
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
        }
    }
}