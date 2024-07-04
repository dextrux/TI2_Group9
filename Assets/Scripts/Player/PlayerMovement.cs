using UnityEngine;
namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool IsMoving;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private byte _lane; // 0: lane 1; 1: lane 2; 2: lane 3;
        [SerializeField] private float _distanceBetweenLane;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _jumpLength;
        [SerializeField] private bool _isJumping;
        [SerializeField] private float _downSpeed;
        [SerializeField] private bool _isSliding;
        [SerializeField] private float _slideDistance;
        private float _slideStartPosition;
        [SerializeField] private Vector3 _targetPosition;
        private float _colliderStartHeight;
        private float _timer;
        private float _actualLane;
        private float _startTimer;
        private float _startPositionSwipe;
        private bool _isMoving;
        private float _endPosition;
        private void Start()
        {
            _timer = Time.time;
            _lane = 1;
            _actualLane = 1;
            _endPosition = 0;
            _isMoving = false;
            _colliderStartHeight = gameObject.GetComponent<BoxCollider>().size.y;
        }
        private void Update()
        {
            if (_actualLane != _lane)
            {
                _startTimer = Time.time;
                _startPositionSwipe = transform.position.x;
                _actualLane = _lane;
                _isMoving = true;
                if (_lane == 0) _endPosition = -2.5f;
                if (_lane == 1) _endPosition = 0;
                if (_lane == 2) _endPosition = 2.5f;
            }
            if (_isMoving)
            {
                float distance = (Time.time - _startTimer) * 6;
                float t = distance / _distanceBetweenLane;
                _targetPosition.x = Mathf.Lerp(_startPositionSwipe, _endPosition, distance);
                if (t >= 1) _isMoving = false;
            }
        }
        private void FixedUpdate()
        {
            if (IsMoving) MoveBetweenLane();
        }

        internal void ChangeLane(bool goRight)
        {
            {
                if (goRight && _lane < 2)
                {
                    _lane++;
                    AudioManager.Instance.TocarSFX(2);
                }
                if (!goRight && _lane > 0)
                {
                    _lane--;
                    AudioManager.Instance.TocarSFX(2);
                }
            }
        }
        private void MoveBetweenLane()
        {
            Vector3 dir = transform.position;
            if (_lane == 0)
            {
                if (transform.position.x > -_distanceBetweenLane) dir = new Vector3(_targetPosition.x, transform.position.y, transform.position.z);
            }
            else if (_lane == 1)
            {
                if (transform.position.x > 0 || transform.position.x < 0) dir = new Vector3(_targetPosition.x, transform.position.y, transform.position.z);
            }
            else if (_lane == 2)
            {
                if (transform.position.x < _distanceBetweenLane) dir = new Vector3(_targetPosition.x, transform.position.y, transform.position.z);
            }
            dir.z += 1 * _speed;
            _rigidBody.MovePosition(dir);
        }
        public void ResetChar()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
        public void SetSpeedZero()
        {
            _speed = 0;
        }
        public void SetSpeedNormal()
        {
            _speed = 0.2F;
        }
    }
}