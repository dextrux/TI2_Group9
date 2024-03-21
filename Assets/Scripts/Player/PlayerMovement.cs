using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
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
            Jumping();
            Sliding();
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _targetPosition.y, transform.position.z), _speed * Time.deltaTime);
        }
        private void FixedUpdate()
        {
            _rigidBody.velocity = transform.forward * _speed;
            MoveBetweenLane();
        }

        internal void ChangeLane(bool goRight)
        {
            if (goRight && _lane < 2)
            {
                _lane++;
            }
            if (!goRight && _lane > 0)
            {
                _lane--;
            }
        }
        private void MoveBetweenLane()
        {
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (_lane == 0)
            {
                targetPosition += Vector3.left * _distanceBetweenLane;
            }
            else if (_lane == 2)
            {
                targetPosition += Vector3.right * _distanceBetweenLane;
            }
            transform.position = targetPosition;
        }
        private void Jumping()
        {
            if (_isJumping)
            {
                Physics.gravity = new Vector3(0, -9.8F, 0);
                float ratio = (transform.position.z - _jumpStartPosition) / _jumpLength;
                if (ratio >= 1F)
                {
                    _isJumping = false;
                }
                else
                {
                    _targetPosition.y = Mathf.Sin(ratio * Mathf.PI) * _jumpHeight;
                }
            }
            else if (!_isSliding)
            {
                Physics.gravity = new Vector3(0, -9.8F, 0);
            }
            else if (_isSliding)
            {
                Physics.gravity = new Vector3(0, -50, 0);
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
    }
}