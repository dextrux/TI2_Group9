using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        private void Start()
        {
            _lane = 1;
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
    }
}

