using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace _GAME.Player
{
    public class PlayerFeature : MonoBehaviour
    {
        public Action<Common.RagdollPartRefs> OnClickToRagdollPart;

        public Common.Ragdoll Ragdoll;
        [ReadOnly] public Vector3 PlayerDefaultPosition;
    }
}