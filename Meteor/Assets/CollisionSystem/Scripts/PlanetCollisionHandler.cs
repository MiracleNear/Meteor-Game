using System;
using GameObstacles;
using GameObstacles.MeteorObstacle;
using UnityEngine;

namespace CollisionSystem.Scripts
{
    public class PlanetCollisionHandler : CollisionHandler
    {
        public event Action<CrashPlace> CraterFormed; 
        
        public override void HandleСollisionWith(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Meteor meteor))
            {
                ContactPoint contactPoint = collision.contacts[0];

                Vector3 lookDirection = Vector3.Cross(contactPoint.normal, transform.right);

                CrashPlace crashPlace = new CrashPlace(contactPoint.normal, lookDirection, meteor.transform.right,
                    contactPoint.point);

                CraterFormed?.Invoke(crashPlace);
            }
        }
    }
}