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
            if (Touch.activeFingers.Count == 1)
            {
                Touch activeTouch = Touch.activeFingers[0].currentTouch;
            }
        }
        private void HoldOnMenu()
        {
            if (Time.time > timer)
            {
                timer = Time.time + 0.05F;
                if (Touch.activeFingers.Count == 1)
                {
                    Debug.Log(Touch.activeFingers[0].currentTouch.delta);
                    if (Touch.activeFingers[0].currentTouch.startScreenPosition.x > Touch.activeFingers[0].currentTouch.screenPosition.x)
                    {
                        transform.Rotate(new Vector3(0, (transform.rotation.y + 10), 0));
                    }
                    else if (Touch.activeFingers[0].currentTouch.startScreenPosition.x < Touch.activeFingers[0].currentTouch.screenPosition.x)
                    {
                        transform.Rotate(new Vector3(0, (transform.rotation.y - 10), 0));
                    }
                }
            }
        }
        private void PlayingGame()
        {
            if (Touch.activeFingers.Count == 1)
            {
                //Debug.Log("Started: " + Touch.activeFingers[0].currentTouch.startScreenPosition.x);
                //if (Touch.activeFingers[0].currentTouch.ended) Debug.Log("Ended: " + Touch.activeFingers[0].currentTouch.screenPosition.x);
                if (Touch.activeFingers[0].currentTouch.ended && Touch.activeFingers[0].currentTouch.startScreenPosition.x > Touch.activeFingers[0].currentTouch.screenPosition.x)
                {
                    Debug.Log("Direita");
                    _playerMovement.ChangeLane(false);
                }
                if (Touch.activeFingers[0].currentTouch.ended && Touch.activeFingers[0].currentTouch.startScreenPosition.x < Touch.activeFingers[0].currentTouch.screenPosition.x)
                {
                    Debug.Log("Esquerda");
                    _playerMovement.ChangeLane(true);
                }
                /*if (Touch.activeFingers[0].currentTouch.startScreenPosition.y > Touch.activeFingers[0].currentTouch.screenPosition.y && Touch.activeFingers[0].currentTouch.delta.y > 4)
                {
                    _playerMovement.Jump();
                }
                else if (Touch.activeFingers[0].currentTouch.startScreenPosition.y < Touch.activeFingers[0].currentTouch.screenPosition.y && Mathf.Abs(Touch.activeFingers[0].currentTouch.delta.x) > 4)
                {
                    _playerMovement.Slide();
                }*/
            }
            if (Touch.activeTouches.Count == 2)
            {
                Debug.Log("Ativação de Habilidade");
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