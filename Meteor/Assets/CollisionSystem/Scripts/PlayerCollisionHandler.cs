using System;
using CollisionSystem.Scripts;
using GameObstacles;
using UnityEngine;

namespace CollisionSystem
{
    public class PlayerCollisionHandler : CollisionHandler
    {
        public event Action ObstacleAnEncountered;
        public override void HandleСollisionWith(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
            {
                ObstacleAnEncountered?.Invoke();
            }
        }
    }
}