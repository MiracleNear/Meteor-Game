using System;
using CollisionSystem.Scripts;
using GameSystem;
using UnityEngine;

namespace GameObstacles.CraterObstacle
{
    [RequireComponent(typeof(CraterCollisionHandler))]
    public class Crater : Obstacle, IPauseHandler
    {
        public override event Action<GameObject> Destroying;
        
        [SerializeField] private float _lifeTimeInSeconds;
        [SerializeField] private Vector3 _targetScale;

        private Vector3 _startScale;
        private float _destructionStartTimeLife;
        private CraterCollisionHandler _craterCollision;
        
        private bool _isPaused;

        private void Awake()
        {
            _craterCollision = GetComponent<CraterCollisionHandler>();
        }

        private void OnEnable()
        {
            _craterCollision.EncounteredWithMeteor += OnEncounteredWithMeteor;
        }

        private void Start()
        {
            _startScale = transform.localScale;
            _destructionStartTimeLife = Time.time;
        }

        private void OnDisable()
        {
            _craterCollision.EncounteredWithMeteor -= OnEncounteredWithMeteor;
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

        private void OnEncounteredWithMeteor()
        {
            _destructionStartTimeLife = Time.time;
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}