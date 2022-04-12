using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class GamePause : MonoBehaviour
    {
        [SerializeField] private Button _pause;
        [SerializeField] private GamePauseScreen _gamePauseScreen;
        [SerializeField] private float _timeFillScreen;
        [SerializeField] private float _delay;
        [SerializeField] private GameStarter _gameStarter;

        private bool _isPaused = false;
        
        private void OnEnable()
        {
            _pause.onClick.AddListener(OnButtonPauseClick);
            _gameStarter.GameStarted += OnGameStarted;
        }

        private void Start()
        {
            _pause.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _pause.onClick.RemoveListener(OnButtonPauseClick);
            _gameStarter.GameStarted -= OnGameStarted;
        }

        private void OnButtonPauseClick()
        {
            if(SceneContext.Instance.GameOver.IsGameOver) return;
            
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                _gamePauseScreen.Show();
                StartCoroutine(nameof(FadeScreen));
            }
            else
            {
                _gamePauseScreen.Hide();
                StopCoroutine(nameof(FadeScreen));
            }
            
            ProjectContext.Instance.PauseManager.SetPaused(_isPaused);
        }

        private void OnGameStarted()
        {
            _pause.gameObject.SetActive(true);
        }

        private IEnumerator FadeScreen()
        {
            float alpha = 0f;

            int sign = 1;
            
            while (true)
            {
                float t = _timeFillScreen;
            
                while (t > 0)
                {
                    _gamePauseScreen.SetAlpha(alpha);
                    
                    alpha = alpha + sign * (Time.deltaTime / _timeFillScreen);
                    t -= Time.deltaTime;
                    yield return null;
                }

                sign *= -1;
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}
