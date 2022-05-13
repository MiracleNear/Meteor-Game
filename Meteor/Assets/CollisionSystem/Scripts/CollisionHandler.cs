using System;
using UnityEngine;

namespace CollisionSystem.Scripts
{
    [RequireComponent(typeof(CollisionDetector))]
    public abstract class CollisionHandler : MonoBehaviour, ICollisionHandler
    {
        private CollisionDetector _collisionDetector;
        
        private void Awake()
        {
            _collisionDetector = GetComponent<CollisionDetector>();
        }

        private void Start()
        {
            _collisionDetector.Init(GetComponent<ICollisionHandler>());
        }

        public abstract void HandleСollisionWith(Collision collision);
    }
}