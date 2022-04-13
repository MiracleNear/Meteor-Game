using UnityEngine;

namespace GameSystem
{
    public class GameAccelerator : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _gameAcceleration;
        [SerializeField] private float _distanceToAchieveMaximumGameSpeed;

        private float _currentDistanceTraveledByPlayer;
        private DistanceCounter _distanceCounter;
        private GameAccelerationView _gameAccelerationView;
        private float _time;

        private void Awake()
        {
            _distanceCounter = FindObjectOfType<DistanceCounter>();
            _gameAccelerationView = FindObjectOfType<GameAccelerationView>();
        }

        private void OnEnable()
        {
            _distanceCounter.DistanceCounted += OnDistanceCounted;
        }

        private void OnDisable()
        {
            _distanceCounter.DistanceCounted -= OnDistanceCounted;
        }

        private void OnDistanceCounted(float distance)
        {
            float scale = _gameAcceleration.Evaluate(distance / _distanceToAchieveMaximumGameSpeed);
            
            _gameAccelerationView.SetAccelerationValue(scale);
            Time.timeScale = scale;
        }
    }
}
