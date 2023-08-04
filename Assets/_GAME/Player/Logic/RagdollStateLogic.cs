using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace _GAME.Player
{
    public class RagdollStateLogic : MonoBehaviour
    {
        private void Awake()
        {
            Features.Player.OnClickToRagdollPart += ActivateRagdoll;
            Features.Level.OnLevelToDefault += RagdollToDefault;
            Features.Level.OnLevelToDefault += StopAllCoroutines;

            Features.Player.PlayerDefaultPosition = Features.Player.Ragdoll.transform.position;
        }

        private void ActivateRagdoll(Common.RagdollPartRefs clickedPart)
        {
            Features.Player.Ragdoll.ActivateRagdoll();
            Features.Player.Ragdoll.AddForce(new Vector3(0, 1000, -3000), ForceMode.Force);

            clickedPart.Rigidbody.AddForce(Vector3.back * 10000, ForceMode.Force);

            StopAllCoroutines();
            StartCoroutine(TryToWakeUpCoroutine());
        }

        private IEnumerator TryToWakeUpCoroutine()
        {
            WaitForSeconds wait = new WaitForSeconds(2);
            bool isRagdollActive = true;
            while (isRagdollActive)
            {
                yield return wait;

                if (Features.Player.Ragdoll.Parts[0].Rigidbody.velocity.sqrMagnitude < 1)
                {
                    isRagdollActive = false;
                    Features.Player.Ragdoll.DeactivateRagdoll();
                }
            }
        }

        private void RagdollToDefault()
        {
            Features.Player.Ragdoll.DisableColliders();
            Features.Player.Ragdoll.DeactivateRagdoll();

            Features.Player.Ragdoll.transform.DOJump(Features.Player.PlayerDefaultPosition, 4, 1, 2f)
            .OnComplete(() =>
            {
                Features.Player.Ragdoll.ActivateColliders();
            });
        }
    }
}
