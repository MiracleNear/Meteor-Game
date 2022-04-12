using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPreesPlay);
            _quitButton.onClick.AddListener(OnPressExit);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPreesPlay);
            _quitButton.onClick.RemoveListener(OnPressExit);
        }

        private void OnPressExit()
        {
            Application.Quit();
        }

        private void OnPreesPlay()
        {
            ProjectContext.Instance.SceneLoader.LoadAsyncScene("MainScene");
        }
    }
}
