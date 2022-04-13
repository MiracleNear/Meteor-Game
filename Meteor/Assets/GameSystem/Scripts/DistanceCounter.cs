using System;
using PlayerController;
using UnityEngine;

namespace GameSystem
{
    public class DistanceCounter : MonoBehaviour, IPauseHandler
    {
        public event Action<float> DistanceCounted;
        
        private Player _player;
        private Planet _planet;
        private Vector3 _lastPosition;
        private float _distanceTraveled;
        private bool _isPaused;
        private bool _isStopCounted;
        
        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _planet = FindObjectOfType<Planet>();
            
        }

        private void OnEnable()
        {
            _player.Died += OnPlayerDied;
        }

        private void OnDisable()
        {
            _player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            _isStopCounted = true;
        }

        private void Update()
        {
            if (_isPaused || _isStopCounted) return;
            
             Vector3 currentPosition = _player.transform.position;
            
             float angle = Vector3.Angle(_lastPosition, currentPosition) * Mathf.Deg2Rad;
            
             _distanceTraveled += angle * _planet.Radius;

             _lastPosition = currentPosition;
             
             DistanceCounted?.Invoke(_distanceTraveled);
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}