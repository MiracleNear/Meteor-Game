using GameSystem;
using UnityEngine;

namespace AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class Turntable : MonoBehaviour, IPauseHandler
    {
        protected AudioSource AudioSource;

        private void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
            
            Initialize();
        }

        protected virtual void Initialize()
        {
            
        }
        
        public virtual void SetPaused(bool isPaused)
        {
            if (isPaused)
            {
                AudioSource.Pause();
            }
            else
            {
                AudioSource.Play();
            }
        }
    }
}
