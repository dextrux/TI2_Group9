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

            }
            else if (_menuInput)
            {
                HoldOnMenu();
            }
            if (Touch.activeFingers.Count == 1)
            {
                Touch activeTouch = Touch.activeFingers[0].currentTouch;

                //Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");
                Debug.Log(activeTouch.delta);
            }
            //GetInput();
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
        public void EnableMenuMode()
        {
            _menuInput = true;
            _playingInput = false;
        }
        public void DisableMenuMode()
        {
            _menuInput = false;
            _playingInput = false;
        }
        public void ResetModelPosition()
        {
            _modelOnMenu.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
        }
        /*
        private void GetInput()
        {
            if (Input.touchCount > 0)
            {
                Touch firstTouch = Input.GetTouch(0);
                if (firstTouch.phase == UnityEngine.TouchPhase.Began)
                {
                    startTouchPos = firstTouch.position;
                    endTouchPos = firstTouch.position;
                }
                if (firstTouch.phase == UnityEngine.TouchPhase.Ended)
                {
                    endTouchPos = firstTouch.position;
                    if (startTouchPos.x > endTouchPos.x)
                    {
                        _playerMovement.ChangeLane(false);
                    }
                    if (startTouchPos.x < endTouchPos.x)
                    {
                        _playerMovement.ChangeLane(true);
                    }
                    if (startTouchPos.y < endTouchPos.y)
                    {
                        _playerMovement.Jump();
                    }
                    if (startTouchPos.y > endTouchPos.y)
                    {
                        _playerMovement.Slide();
                    }
                }
            }
        
        }*/
    }
}
