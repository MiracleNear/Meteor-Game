using GameSystem;
using PlayerController;
using UnityEngine;

namespace SmoothCameraFollowing
{
    public class FollowingCamera : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private Player _targetFollowing;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothDampTime;
        [SerializeField] private float _rotationSmootingSpeed;
        
        private Transform _target;
        private Vector3 _velocityDamp;

        private bool _isPaused;

        private void OnValidate()
        {
            if (_targetFollowing != null)
            {
                transform.position = _targetFollowing.transform.position + _offset;
            }
        }

        private void Awake()
        {
            if (_targetFollowing != null)
            {
                _target = _targetFollowing.transform;
            }
        }
        
        private void FixedUpdate()
        {
            if(_targetFollowing == null || _isPaused) return;

            Quaternion deflection = _target.rotation;
            
            Vector3 trackingDirection = (deflection * _offset);

            Move(trackingDirection);
            Rotate(trackingDirection);
        }

        private void Rotate(Vector3 direction)
        {
            Quaternion from = transform.rotation;
            Quaternion lookDirection = Quaternion.LookRotation(-direction, _target.transform.forward);

            transform.rotation = Quaternion.Slerp(from, lookDirection, _rotationSmootingSpeed * Time.deltaTime);
        }
        private void Move(Vector3 direction)
        {
            Vector3 targetPosition = _targetFollowing.transform.position;
            Vector3 targetCameraPosition = targetPosition + direction;
            
            transform.position = Vector3.SmoothDamp(transform.position, targetCameraPosition, ref _velocityDamp, _smoothDampTime);
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}