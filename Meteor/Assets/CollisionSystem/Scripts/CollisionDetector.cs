using UnityEngine;

namespace CollisionSystem.Scripts
{
    
    public class CollisionDetector : MonoBehaviour
    {
        private ICollisionHandler _collisionHandler;

        public void Init(ICollisionHandler collisionHandler)
        {
            _collisionHandler = collisionHandler;
        }

        private void OnCollisionEnter(Collision other)
        {
            _collisionHandler.HandleСollisionWith(other);
        }
    }
}