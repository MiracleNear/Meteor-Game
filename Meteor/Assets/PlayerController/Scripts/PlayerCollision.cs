using System;
using GameObstacles;
using UnityEngine;

namespace PlayerController
{
    public class PlayerCollision : MonoBehaviour
    {
        public event Action ObstacleAnEncountered;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Obstacle obstacle))
            {
                ObstacleAnEncountered?.Invoke();
            }
        }
    }
}