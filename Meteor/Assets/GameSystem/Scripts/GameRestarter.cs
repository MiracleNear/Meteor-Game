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

            ProjectContext.Instance.SceneLoader.LoadAsyncScene(SceneID.MainScene);
        }

        private void ExitMenu()
        {
            ProjectContext.Instance.SceneLoader.LoadAsyncScene(SceneID.Menu);
        }
    }
}