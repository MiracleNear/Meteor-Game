using System;
using GameSystem;
using UnityEngine;

namespace PlayerController
{
    public class SurfaceSlider : MonoBehaviour
    {
        [SerializeField] private Collider _surface;
        
        public Vector3 GetNormalSurface()
        {
            RaycastHit hitInfo = new RaycastHit();

            Vector3 origin = transform.position;
            Vector3 direction = (_surface.transform.position - transform.position).normalized;

            Ray rayToSurface = new Ray(origin, direction);

            _surface.Raycast(rayToSurface, out hitInfo, Mathf.Infinity);

            return hitInfo.normal;
        }
        
        public Vector3 ProjectOnGround(Vector3 direction, Vector3 normal)
        {
            return direction - Vector3.Dot(direction, normal) * normal;
        }
    }
}
