using System;
using GameSystem;
using UnityEngine;
using InputSystem;

namespace PlayerController
{
    [RequireComponent(typeof(SurfaceSlider), typeof(Rigidbody), typeof(PlayerCollision))]
    public class Player : MonoBehaviour, IPauseHandler
    {
        public event Action Died; 
        
        [SerializeField] private float _speed;
        [SerializeField] private float _angularSpeed;

        private SurfaceSlider _surfaceSlider;
        private Rigidbody _rigidbody;
        private IInput _input;
        private float _rotationInputValue;
        private PlayerCollision _playerCollision;

        private bool _isPaused { get; set; }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _surfaceSlider = GetComponent<SurfaceSlider>();
            _playerCollision = GetComponent<PlayerCollision>();
        }

        private void OnEnable()
        {
            _playerCollision.ObstacleAnEncountered += OnObstacleAnEncountered;
        }

        private void Start()
        {
            _input = ProjectContext.Instance.Input;
            
            _input.RotatePressed += OnRotatePressed;
            _input.RotateDepressed += OnRotateDepressed;
        }

        private void OnDisable()
        {
            _playerCollision.ObstacleAnEncountered -= OnObstacleAnEncountered;
        }

        private void OnDestroy()
        {
            _input.RotateDepressed -= OnRotateDepressed;
            _input.RotatePressed -= OnRotatePressed;
        }

        private void OnRotateDepressed()
        {
            _rotationInputValue = _input.RotationValue;
        }

        private void OnRotatePressed()
        {
            _rotationInputValue = _input.RotationValue;
        }
        
        private void OnObstacleAnEncountered()
        {
            Destroy(gameObject);
            
            Died?.Invoke();
        }

        
        private void FixedUpdate()
        {
            if(_isPaused) return;
            
            Vector3 directionMove = transform.forward;
            Vector3 normalSurface = _surfaceSlider.GetNormalSurface();
            
            directionMove = _surfaceSlider.ProjectOnGround(directionMove, normalSurface);
            
            Move(directionMove);
            Rotate(transform.up, normalSurface);
            RotateAround(normalSurface);
        }

        private void Move(Vector3 direction)
        {
            Vector3 motion = _rigidbody.position + direction * _speed * Time.deltaTime;

            _rigidbody.MovePosition(motion);
        }

        private void Rotate(Vector3 up, Vector3 normalSurface)
        {
            Quaternion correct = Quaternion.FromToRotation(up, normalSurface);

            _rigidbody.MoveRotation(correct * _rigidbody.rotation);
        }

        private void RotateAround(Vector3 axisRotation)
        {
           Quaternion to = Quaternion.AngleAxis(_rotationInputValue * _angularSpeed * Time.deltaTime, axisRotation) * _rigidbody.rotation;

           _rigidbody.MoveRotation(to);
        }
        
        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}
