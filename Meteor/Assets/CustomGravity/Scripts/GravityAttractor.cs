using UnityEngine;

namespace CustomGravity
{
    public class GravityAttractor : MonoBehaviour
    {
        [SerializeField] private float _gravity;

        public void Attract(Rigidbody body)
        {
            Vector3 directionGravity = (transform.position - body.position).normalized;
            
            body.AddForce(directionGravity * _gravity, ForceMode.Acceleration);
        }
    }
}