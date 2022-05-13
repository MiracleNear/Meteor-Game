using GameSystem;
using UnityEngine;

namespace AudioSystem.Player
{
    public class PlayerAudio : Turntable
    {
        [SerializeField] private AudioClip _engineSound, _rideSound;
        [SerializeField] private float _pitchOnRide;

        private GameStarter _gameStarter;
        
        protected override void Initialize()
        {
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
            AudioSource.Stop();
            AudioSource.clip = _rideSound;
            AudioSource.pitch = _pitchOnRide;
            AudioSource.loop = true;
            AudioSource.Play();
        }

        private void OnCountdownStarted()
        {
            AudioSource.clip = _engineSound;
            AudioSource.Play();
        }
        
        public override void SetPaused(bool isPaused)
        {
            base.SetPaused(isPaused);
        }
    }
}