using System;
using GameObstacles.CraterObstacle;
using UnityEngine;

namespace GameObstacles.Spawners
{
    public class CraterSpawner : ObstacleSpawner<Crater>
    {
        [SerializeField] private Planet _planet;
        [SerializeField] private Crater _template;
        
        protected override void InitializationSpawner()
        {
            _planet.MeteorFalled += SpawnAt;
        }

        protected override void DeInitializationSpawner()
        {
            _planet.MeteorFalled -= SpawnAt;
        }
        
        private void SpawnAt(CrashPlace crashPlace)
        {
            Quaternion rotation = Quaternion.LookRotation(crashPlace.Forward, crashPlace.Up);
            
            Spawn(_template, crashPlace.Position, rotation);
        }
    }
}