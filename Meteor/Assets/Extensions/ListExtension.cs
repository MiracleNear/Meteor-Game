using System.Collections.Generic;
using GameObstacles.View;
using UnityEngine;

namespace Extensions
{
    public static class ListExtension
    {
        public static Skin GetRandomValue(this List<Skin> list)
        {
            int randomIndex = Random.Range(0, list.Count);

            return list[randomIndex];
        }
    }
}