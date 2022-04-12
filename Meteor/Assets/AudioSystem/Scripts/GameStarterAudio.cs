using System.Collections;
using GameSystem;
using UnityEngine;

namespace AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class GameStarterAudio : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private float _volumeUpTime;
        [SerializeField] private float _maxVolume;
        [SerializeField] private float _volumeOnPaused;

        private float _minVolume = 0f;
        private AudioSource _audioSource;
        private GameStarter _gameStarter;
        private bool _isSmoothlyFillLaunched = false;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            _gameStarter = FindObjectOfType<GameStarter>();
        }

        private void OnEnable()
        {
            _gameStarter.GameStarted += OnGameStarted;
        }

        private void OnDisable()
        {
            _gameStarter.GameStarted -= OnGameStarted;
        }

        private void OnGameStarted()
        {
            _audioSource.Play();
            
            StartCoroutine(SmoothlyFill(_minVolume, _maxVolume));
        }

        private IEnumerator SmoothlyFill(float from, float to)
        {
            _isSmoothlyFillLaunched = true;
            float time = 0f;

            while (time <= _volumeUpTime)
            {
                _audioSource.volume = Mathf.Lerp(from, to, time / _volumeUpTime);
                time += Time.deltaTime;
                yield return null;
            }

            _isSmoothlyFillLaunched = false;
        }

        public void SetPaused(bool isPaused)
        {
            float currentVolume = _audioSource.volume;

            if (_isSmoothlyFillLaunched)
            {
                _isSmoothlyFillLaunched = false;
                StopAllCoroutines();
            }
            
            if (isPaused)
            {
                StartCoroutine(SmoothlyFill(currentVolume, _volumeOnPaused));
            }
            else
            {
                StartCoroutine(SmoothlyFill(currentVolume, _maxVolume));
            }
        }
    }
}
