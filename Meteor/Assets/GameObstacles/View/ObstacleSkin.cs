using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace GameObstacles.View
{
    [CreateAssetMenu(menuName = "Obstacle Skin", order = 0)]
    public class ObstacleSkin : ScriptableObject
    {
        [SerializeField] private List<Skin> _skins;
        public Skin ModelView => _skins.GetRandomValue();
    }
}