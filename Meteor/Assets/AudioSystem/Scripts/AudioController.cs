using GameSystem;
using UnityEngine;

namespace AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour, IPauseHandler
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void SetPaused(bool isPaused)
        {
            if (isPaused)
            {
                _audioSource.Pause();
            }
            else
            {
                _audioSource.UnPause();
            }
        }
    }
}
