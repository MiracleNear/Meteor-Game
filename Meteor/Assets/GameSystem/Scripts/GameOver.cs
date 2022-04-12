using System.Collections;
using PlayerController;
using UnityEngine;

namespace GameSystem
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private GameRestarter _gameRestarter;
        [SerializeField] private float _smoothingTime;
        [SerializeField] private float _minimumSmoothingParameter;
        [SerializeField] private float _maximumSmoothingParameter;
        
        private Player _player;
        
        public bool IsGameOver { get; private set; }

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        private void OnEnable()
        {
            _gameRestarter.LevelRestarted += OnLevelRestarted;

            _player.Died += OnPlayerDied;
        }

        private void OnDisable()
        {
            _gameRestarter.LevelRestarted -= OnLevelRestarted;

            _player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            IsGameOver = true;
            
           _gameOverScreen.Show();

           StartCoroutine(nameof(SmoothingText));
        }

        private void OnLevelRestarted()
        {
            IsGameOver = false;
            
            StopCoroutine(nameof(SmoothingText));
        }
        
        
        private IEnumerator SmoothingText()
        {
            float currentMinimum = _minimumSmoothingParameter;
            float currentMaximum = _maximumSmoothingParameter;
            
            while (true)
            {
                float t = 0f;

                float deltaDistance = currentMinimum;
                
                while (t <= _smoothingTime)
                {
                    _gameOverScreen.SetWordSpacing(deltaDistance);
                    _gameOverScreen.SetCharacterSpacing(deltaDistance / 5f);
                    deltaDistance = Mathf.Lerp(currentMinimum, currentMaximum, (t / _smoothingTime));
                    t += (Time.deltaTime / Time.timeScale);
                    yield return null;
                }

                float temp = currentMinimum;
                currentMinimum = currentMaximum;
                currentMaximum = temp;
                
                yield return null;
            }
        }
    }
}
