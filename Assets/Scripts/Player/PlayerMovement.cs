using UnityEngine;
namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
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
        private float _jumpStartPosition;
        private Vector3 _targetPosition;
        private float _colliderStartHeight;
        private void Start()
        {
            _lane = 1;
            _colliderStartHeight = gameObject.GetComponent<BoxCollider>().size.y;
        }
        private void Update()
        {
            //Jumping();
            //Sliding();
            MoveBetweenLane();
        }
        private void FixedUpdate()
        {
            SetVelocityPlayer();
        }

        internal void ChangeLane(bool goRight)
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
        private void MoveBetweenLane()
        {
            if (_lane == 0)
            {
                _targetPosition = new Vector3(-_distanceBetweenLane, transform.position.y, transform.position.z);
            }

            else if (_lane == 1)
            {
                _targetPosition = new Vector3(0,transform.position.y, transform.position.z);
            }
            else if (_lane == 2)
            {
                _targetPosition = new Vector3(_distanceBetweenLane, transform.position.y, transform.position.z);
            }
        }
        private void Jumping()
        {
            if (_isJumping)
            {
                float ratio = (transform.position.z - _jumpStartPosition) / _jumpLength;
                if (ratio >= 1F)
                {
                    _isJumping = false;
                }
                else
                {
                    _targetPosition.y = Mathf.Sin(ratio * Mathf.PI) * _jumpHeight;
                    //_rigidBody.Move(new Vector3(transform.position.x, _targetPosition.y, transform.position.z), Quaternion.identity);
                }
            }
        }
        private void Sliding()
        {
            if (_isSliding)
            {
                float ratio = (transform.position.z - _slideStartPosition) / _slideDistance;
                if (ratio >= 1F)
                {
                    gameObject.GetComponent<BoxCollider>().size = new Vector3(0, _colliderStartHeight, 0);
                    _isSliding = false;
                }
            }
        }
        internal void Jump()
        {
            if (!_isJumping)
            {
                _jumpStartPosition = transform.position.z;
                _isJumping = true;
            }
        }
        internal void Slide()
        {
            if (!_isSliding)
            {
                _slideStartPosition = transform.position.z;
                _isSliding = true;
                gameObject.GetComponent<BoxCollider>().size = new Vector3(0, _colliderStartHeight / 2, 0);
            }
        }
        public void SetVelocityPlayer()
        {
            _targetPosition = transform.position + (Vector3.forward * _speed * Time.deltaTime);
            transform.position = _targetPosition;
        }
    }
}