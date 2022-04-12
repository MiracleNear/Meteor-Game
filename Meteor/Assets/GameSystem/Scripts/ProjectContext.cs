using InputSystem;
using InputSystem.PCInput;
using UnityEngine;

namespace GameSystem
{
    [RequireComponent(typeof(SceneLoader), typeof(PauseManager))]
    public class ProjectContext : MonoBehaviour
    {
        public static ProjectContext Instance { get; private set; }
        
        public PauseManager PauseManager { get; private set; }
        public SceneLoader SceneLoader { get; private set; }
        
        public IInput Input { get; private set; }
        

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if(Instance == this)
            {
                Destroy(gameObject);
            }
            
            DontDestroyOnLoad(gameObject);

            Input = gameObject.AddComponent<InputKeyboardHandler>();
            
            PauseManager = GetComponent<PauseManager>();
            SceneLoader = GetComponent<SceneLoader>();
        }
    }
}