using UnityEngine;
using UnityEngine.InputSystem;
namespace Player
{
    public class InputControl : MonoBehaviour
    {
        Vector2 startTouchPos, endTouchPos;
        [SerializeField] private PlayerMovement _playerMovement;
        private void Update()
        {
            GetInput();
        }
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
        }
    }
}
