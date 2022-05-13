using UnityEngine;

namespace CollisionSystem.Scripts
{
    public interface ICollisionHandler
    {
        public void HandleСollisionWith(Collision collision);
    }
}