using GameSystem;
using UnityEngine;

namespace GameObstacles.MeteorObstacle
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ExplosionView : MonoBehaviour, IPauseHandler
    {
        private ParticleSystem _explosionFX;

        private void Awake()
        {
            _explosionFX = GetComponent<ParticleSystem>();
        }

        public void SetPaused(bool isPaused)
        {
            if(isPaused) _explosionFX.Pause();
            else _explosionFX.Play();
        }
    }
}
