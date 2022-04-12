using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class GameRestarter : MonoBehaviour
    {
        public event Action LevelRestarted;
        
        [SerializeField] private Button _sceneRestart;
        [SerializeField] private Button _exitToMenu;
        [SerializeField] private string _sceneToRestart;
        [SerializeField] private string _menuScene;
        
        private void OnEnable()
        {
            _sceneRestart.onClick.AddListener(ReloadLevel);
            _exitToMenu.onClick.AddListener(ExitMenu);
        }

        private void OnDisable()
        {
            _sceneRestart.onClick.RemoveListener(ReloadLevel);
            _exitToMenu.onClick.RemoveListener(ExitMenu);
        }

        private void ReloadLevel()
        {
            LevelRestarted?.Invoke();

            ProjectContext.Instance.SceneLoader.LoadAsyncScene(_sceneToRestart);
        }

        private void ExitMenu()
        {
            ProjectContext.Instance.SceneLoader.LoadAsyncScene(_menuScene);
        }
    }
}