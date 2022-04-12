using System;
using Unity.Mathematics;
using UnityEngine;

namespace GameObstacles.MeteorObstacle
{
    public class Meteor : Obstacle
    {
        public override event Action<GameObject> Destroying;
        
        [SerializeField] private ParticleSystem _destroyEffect;
        
        private Planet _lookTarget;

        private void Awake()
        {
            _lookTarget = FindObjectOfType<Planet>();
        }

        private void Start()
        {
            Vector3 directionLook = (_lookTarget.transform.position - transform.position).normalized;
            
            Quaternion rotation = Quaternion.LookRotation(directionLook, Vector3.up);

            transform.rotation = rotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            Quaternion rotation = quaternion.LookRotation(Vector3.forward, -transform.forward);

            Instantiate(_destroyEffect, transform.position, rotation);
            
            Destroying?.Invoke(gameObject);
        }
    }
}
