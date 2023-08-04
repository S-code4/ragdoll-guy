using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _GAME.Common
{
    public class Ragdoll : MonoBehaviour
    {
        public Animator Animator;
        public List<RagdollPartRefs> Parts = new List<RagdollPartRefs>();
        [Space]
        public float DeactivationDuration = 0.3f;

        [ContextMenu("Init Ragdoll")]
        public void InitRagdoll()
        {
            Parts.Clear();

            Animator = GetComponent<Animator>();

            GetComponentsInChildren<RagdollPartRefs>(Parts);

            foreach (RagdollPartRefs part in Parts)
            {
                part.InitPart();

                var rb = part.Rigidbody;
                rb.isKinematic = true;
                rb.useGravity = false;

                var col = part.Collider;
                col.isTrigger = true;
                col.enabled = true;
            }
        }

        [ContextMenu("Activate Ragdoll")]
        public void ActivateRagdoll()
        {
            StopAllCoroutines();

            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].transform.DOKill();

                if (Animator.enabled)
                {
                    Parts[i].StartLocalPosition = Parts[i].transform.localPosition;
                    Parts[i].StartLocalRotation = Parts[i].transform.localEulerAngles;
                }

                Parts[i].Rigidbody.isKinematic = false;
                Parts[i].Rigidbody.useGravity = true;
            }

            Animator.enabled = false;
        }

        [ContextMenu("Deactivate Ragdoll")]
        public void DeactivateRagdoll()
        {
            Physics.Raycast(Parts[0].transform.position, Vector3.down, out RaycastHit hit, 5f, Features.Level.GroundLayer);

            Vector3 DeltaMoveOrigin = hit.point - Features.Player.Ragdoll.transform.position;
            Features.Player.Ragdoll.transform.position += DeltaMoveOrigin;
            Features.Player.Ragdoll.Parts[0].transform.position -= DeltaMoveOrigin;

            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].Rigidbody.isKinematic = true;
                Parts[i].Rigidbody.useGravity = false;

                Parts[i].transform.DOLocalRotate(Parts[i].StartLocalRotation, DeactivationDuration);
                Parts[i].transform.DOLocalMove(Parts[i].StartLocalPosition, DeactivationDuration);
            }

            this.DelayedCall(DeactivationDuration, () => Animator.enabled = true);
        }

        [ContextMenu("Activate Colliders")]
        public void ActivateColliders()
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].Collider.enabled = true;
            }
        }

        [ContextMenu("Disable Colliders")]
        public void DisableColliders()
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].Collider.enabled = false;
            }
        }

        public void AddForce(Vector3 forcePowerDirection, ForceMode forceMode)
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].Rigidbody.isKinematic = false;
                Parts[i].Rigidbody.useGravity = true;

                Parts[i].Rigidbody.AddForce(forcePowerDirection, forceMode);
            }
        }
    }
}
