using GameSystem;
using UnityEngine;

namespace GameObstacles.Spawners
{
    public abstract class ObstacleSpawner<T> : MonoBehaviour, IPauseHandler where T : Obstacle
    {
        public void SetPaused(bool isPaused)
        {
            if (isPaused)
            {
                DeInitializationSpawner();
            }
            else
            {
                InitializationSpawner();
            }
        }
        
        private void OnEnable()
        {
            InitializationSpawner();
            
        }
        
        private void OnDisable()
        {
            DeInitializationSpawner();
        }

        protected abstract void InitializationSpawner();

        protected abstract void DeInitializationSpawner();


        protected void Spawn(T template, Vector3 position, Quaternion rotation)
        {
            Obstacle obstacle = Instantiate(template, position, rotation, transform);

            obstacle.Destroying += Destroy;
        }
    }
}