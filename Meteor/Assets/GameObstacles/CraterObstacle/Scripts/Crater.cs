using System;
using GameObstacles.MeteorObstacle;
using GameSystem;
using UnityEngine;

namespace GameObstacles.CraterObstacle
{
    public class Crater : Obstacle, IPauseHandler
    {
        public override event Action<GameObject> Destroying;
        
        [SerializeField] private float _lifeTimeInSeconds;
        [SerializeField] private Vector3 _targetScale;

        private Vector3 _startScale;
        private float _destructionStartTimeLife;

        private bool _isPaused;
        
        private void Start()
        {
            _startScale = transform.localScale;
            _destructionStartTimeLife = Time.time;
        }

        private void Update()
        {
            if(_isPaused) return;

            float pastTenseLifeInSeconds = (Time.time - _destructionStartTimeLife);

            Vector3 intermediateScale =
                Vector3.Lerp(_startScale, _targetScale, pastTenseLifeInSeconds / _lifeTimeInSeconds);

            transform.localScale = intermediateScale;

            if (transform.localScale == _targetScale)
            {
               Destroying?.Invoke(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Meteor meteor))
            {
                _destructionStartTimeLife = Time.time;
            }
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}