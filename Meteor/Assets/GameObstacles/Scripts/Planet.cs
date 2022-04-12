using System;
using GameObstacles;
using GameObstacles.MeteorObstacle;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public event Action<CrashPlace> MeteorFalled; 
    
    [SerializeField] private float _radius;
    public float Radius => _radius;

    private void OnValidate()
    {
        if (_radius <= 0)
        {
            _radius = 1f;
        }

        transform.localScale = Vector3.one * _radius * 2f;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Meteor meteor))
        {
            ContactPoint contactPoint = other.contacts[0];

            Vector3 lookDirection = Vector3.Cross(contactPoint.normal, transform.right);
                
            CrashPlace crashPlace = new CrashPlace(contactPoint.normal, lookDirection, meteor.transform.right, contactPoint.point);
            
            MeteorFalled?.Invoke(crashPlace);
        }
    }
}

