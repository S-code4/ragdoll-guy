using _GAME.Common;
using System;
using UnityEngine;

namespace _GAME.Level
{
    public class LevelFeature : MonoBehaviour
    {
        public Action OnLevelToDefault;

        public LayerMask GroundLayer;
        public RestartButtonRefs RestartButton;
        [Space]
        public CubeRefs[] Cubes;
    }
}