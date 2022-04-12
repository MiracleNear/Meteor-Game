using GameObstacles.View;
using GameSystem;
using UnityEngine;

namespace GameObstacles
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class ObstacleView : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private ObstacleSkin _obstacleSkin;
        [SerializeField] private ParticleSystem _particle;
        
        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        private float _playbackPositionInSecondsBeforePause;

        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            Skin skin = _obstacleSkin.ModelView;

            _meshFilter.mesh = skin.Model;
            _meshRenderer.material = skin.Visual;
        }
        
        public void SetPaused(bool isPaused)
        {
            if (isPaused)
            {
                _particle.Pause();
            }
            else
            {
                _particle.Play();
            }
        }
    }
}