using UnityEngine;

namespace GameSystem
{
    public class SceneContext : MonoBehaviour
    {
        public static SceneContext Instance { get; private set; }
        public GameOver GameOver { get; private set; }

        private void Awake()
        {
            GameOver = FindObjectOfType<GameOver>();
            Instance = this;
        }
    }
}
