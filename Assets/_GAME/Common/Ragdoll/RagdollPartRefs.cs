using System;
using Unity.Collections;
using UnityEngine;

namespace _GAME.Common
{
    [RequireComponent(typeof(ObjectTapCatcher))]
    public class RagdollPartRefs : MonoBehaviour
    {
        public RagdollPartType PartType;
        public ObjectTapCatcher TapCatcher;
        [Space]
        public Rigidbody Rigidbody;
        public Collider Collider;
        [Space]
        [ReadOnly] public Vector3 StartLocalPosition;
        [ReadOnly] public Vector3 StartLocalRotation;

        [ContextMenu("Init Ragdol Part")]
        public void InitPart()
        {
            TapCatcher = GetComponent<ObjectTapCatcher>();
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();

            if (!TapCatcher || !Rigidbody || !Collider)
            {
                Debug.LogWarning("Отсутсвует часть рагдола " + gameObject.GetInstanceID());
            }
        }
    }
}