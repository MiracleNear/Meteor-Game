using System;
using CollisionSystem.Scripts;
using GameObstacles;
using UnityEngine;

[RequireComponent(typeof(PlanetCollisionHandler))]
public class Planet : MonoBehaviour
{
    public event Action<CrashPlace> MeteorFalled;

    [SerializeField] private float _radius;

    private PlanetCollisionHandler _planetCollisionHandler;
    public float Radius => _radius;

    private void OnValidate()
    {
        if (_radius <= 0)
        {
            _radius = 1f;
        }

        transform.localScale = Vector3.one * _radius * 2f;
    }

    private void Awake()
    {
        _planetCollisionHandler = GetComponent<PlanetCollisionHandler>();
    }

    private void OnEnable()
    {
        _planetCollisionHandler.CraterFormed += OnCraterFormed;
    }

    private void OnDisable()
    {
        _planetCollisionHandler.CraterFormed -= OnCraterFormed;
    }

    private void OnCraterFormed(CrashPlace crashPlace)
    {
        MeteorFalled?.Invoke(crashPlace);
    }
}

