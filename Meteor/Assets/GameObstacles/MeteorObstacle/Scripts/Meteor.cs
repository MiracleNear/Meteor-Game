using System;
using CollisionSystem.Scripts;
using UnityEngine;

namespace GameObstacles.MeteorObstacle
{
    [RequireComponent(typeof(MeteorCollisionHandler), typeof(SphereCollider))]
    public class Meteor : Obstacle
    {
        public override event Action<GameObject> Destroying;
        
        [SerializeField] private ParticleSystem _destroyEffect;

        private Planet _lookTarget;
        private MeteorCollisionHandler _meteorCollision;

        private void Awake()
        {
            _lookTarget = FindObjectOfType<Planet>();
            _meteorCollision = GetComponent<MeteorCollisionHandler>();
        }

        private void OnEnable()
        {
            _meteorCollision.Collided += OnCollided;
        }

        private void OnDisable()
        {
            _meteorCollision.Collided -= OnCollided;
        }

        private void Start()
        {
            Vector3 directionLook = (_lookTarget.transform.position - transform.position).normalized;
            
            Quaternion rotation = Quaternion.LookRotation(directionLook, Vector3.up);

            transform.rotation = rotation;
        }

        private void OnCollided()
        {
            _destroyEffect.transform.parent = null;
            _destroyEffect.gameObject.SetActive(true);
            _destroyEffect.Play();
            
            Destroying?.Invoke(gameObject);
        }
    }
}
