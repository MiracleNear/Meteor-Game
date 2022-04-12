using GameSystem;
using UnityEngine;
using UnityEngine.Audio;

namespace PlayerController
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudioView : MonoBehaviour
    {
        [SerializeField] private AudioClip _engineStartSound;
        [SerializeField] private AudioClip _rideSound;
        [SerializeField] private float _pitchOnRide;

        private AudioSource _audioSource;
        private GameStarter _gameStarter;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _gameStarter = FindObjectOfType<GameStarter>();
            
        }

        private void OnEnable()
        {
            _gameStarter.CountdownStarted += OnCountdownStarted;
            _gameStarter.GameStarted += OnGameStarted;
        }

        private void OnDisable()
        {
            _gameStarter.CountdownStarted -= OnCountdownStarted;
            _gameStarter.GameStarted -= OnGameStarted;
        }

        private void OnGameStarted()
        {
            _audioSource.Stop();
            _audioSource.pitch = _pitchOnRide;
            _audioSource.clip = _rideSound;
            _audioSource.loop = true;
            _audioSource.Play();
        }

        private void OnCountdownStarted()
        {
            _audioSource.clip = _engineStartSound;
            _audioSource.Play();
        }
    }
}