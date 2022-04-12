using System;
using UnityEngine;

namespace GameObstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        public abstract event Action<GameObject> Destroying;
        
    }
}