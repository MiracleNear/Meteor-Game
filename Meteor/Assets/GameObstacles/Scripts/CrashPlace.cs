using UnityEngine;

namespace GameObstacles
{
    public struct CrashPlace
    {
        public readonly Vector3 Up;
        public readonly Vector3 Forward;
        public readonly Vector3 Right;
        public readonly Vector3 Position;
        
        public CrashPlace(Vector3 up, Vector3 forward, Vector3 right, Vector3 position)
        {
            Up = up;
            Right = right;
            Position = position;
            Forward = forward;
        }
    }
}