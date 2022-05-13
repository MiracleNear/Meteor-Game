using System;
using UnityEngine;

namespace CollisionSystem.Scripts
{
    public class MeteorCollisionHandler : CollisionHandler
    {
        public event Action Collided; 
        public override void HandleСollisionWith(Collision collision)
        {
            Collided?.Invoke();
        }
    }
}