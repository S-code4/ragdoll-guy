using UnityEngine;
using Sirenix.OdinInspector;

namespace _GAME.Level
{
    public class CubeRefs : MonoBehaviour
    {
        public Rigidbody RigidBody;
        public Collider Collider;
        [ReadOnly] public Vector3 StartPosition;
    }
}
