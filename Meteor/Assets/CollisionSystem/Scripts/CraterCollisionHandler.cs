using System;
using GameObstacles.MeteorObstacle;
using UnityEngine;

namespace CollisionSystem.Scripts
{
    public class CraterCollisionHandler : CollisionHandler
    {
        public event Action EncounteredWithMeteor;
        
        public override void HandleСollisionWith(Collision collision)
        {
            if (gameObject.TryGetComponent(out Meteor meteor))
            {
                EncounteredWithMeteor?.Invoke();
            }
        }
    }
}