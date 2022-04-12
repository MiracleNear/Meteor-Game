using GameSystem;
using UnityEngine;

namespace CustomGravity
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityBody : MonoBehaviour, IPauseHandler
    {
        private GravityAttractor _gravityAttractor;
        private Rigidbody _gravityBody;
        private Vector3 _lastAttract;

        private bool _isPaused;
        
        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
            
            if (isPaused)
            {
                _lastAttract = _gravityBody.velocity;
                _gravityBody.velocity = Vector3.zero;
            }
            else
            {
                _gravityBody.velocity = _lastAttract;
            }
        }
        
        private void Awake()
        {
            _gravityAttractor = FindObjectOfType<GravityAttractor>();
            _gravityBody = GetComponent<Rigidbody>();
        }
        

        private void FixedUpdate()
        {
            if(_isPaused) return;

            _gravityAttractor.Attract(_gravityBody);
        }
        
    }
}