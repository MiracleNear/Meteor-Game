using System;
using System.Collections;
using UnityEngine;

namespace GameSystem
{
    public class GameStarter : MonoBehaviour
    {
        public event Action CountdownStarted;
        public event Action GameStarted;
    
        [SerializeField] private float _fadeTime;
        [SerializeField] private GameStarterView _gameStarterView;
        
        private string[] _gameStartInformation;

        private void Awake()
        {
            _gameStartInformation = new string[]
            {
                "3",
                "2",
                "1",
                "GO!",
            };
        }

        private void Start()
        {
            ProjectContext.Instance.PauseManager.SetPaused(true);

            StartCoroutine(nameof(GameLaunch));
        }

        private IEnumerator GameLaunch()
        {
            _gameStarterView.Show();
            
            CountdownStarted?.Invoke();
            
            foreach (string info in _gameStartInformation)
            {
                float t = _fadeTime;
                float aplha = 1f;
                
                _gameStarterView.UpdateCountDownCounter(info);
                
                while (t > 0)
                {
                    _gameStarterView.SetAlpha(aplha);
                    
                    t -= Time.deltaTime;
                    aplha -= Time.deltaTime / _fadeTime;
                    
                    yield return null;
                }

                yield return null;
            }
            
            ProjectContext.Instance.PauseManager.SetPaused(false);
            GameStarted?.Invoke();
            _gameStarterView.Hide();
        }
    }
}