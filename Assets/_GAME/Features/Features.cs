using UnityEngine;

namespace _GAME
{
    public class Features : MonoBehaviour
    {
        public static Player.PlayerFeature Player;
        public static Level.LevelFeature Level;

        public void Awake()
        {
            Player = GetComponentInChildren<Player.PlayerFeature>();
            Level = GetComponentInChildren<Level.LevelFeature>();
        }
    }
}