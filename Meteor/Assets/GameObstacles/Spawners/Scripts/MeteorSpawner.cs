using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using GameObstacles.MeteorObstacle;

namespace GameObstacles.Spawners
{
    public class MeteorSpawner : ObstacleSpawner<Meteor>
    {
        [SerializeField] private Planet _planet;
        [SerializeField] private Meteor _template;
        [SerializeField] private float _spawnDistanceFromPlanet;
        [SerializeField] private float _delayBeforeAppearance;
        
        protected override void InitializationSpawner()
        {
            StartCoroutine(nameof(Spawn));
        }

        protected override void DeInitializationSpawner()
        {
            StopCoroutine(nameof(Spawn));
        }
        
        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_delayBeforeAppearance);
             
                Vector3 randomPositionInPlanet = Random.onUnitSphere * _planet.Radius;

                Vector3 positionSpawn = randomPositionInPlanet * _spawnDistanceFromPlanet;
                
                Spawn(_template, positionSpawn, Quaternion.identity);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.2f);
            Gizmos.DrawSphere(_planet.transform.position, _planet.Radius * _spawnDistanceFromPlanet);
            Gizmos.color = Color.white;
        }
    }
}