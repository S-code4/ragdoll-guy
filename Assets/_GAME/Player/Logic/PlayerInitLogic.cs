using UnityEngine;

namespace _GAME.Player
{
    public class PlayerInitLogic : MonoBehaviour
    {
        private void Awake()
        {
            InitPlayer();
        }

        private void InitPlayer()
        {
            Features.Player.PlayerDefaultPosition = Features.Player.transform.position;

            foreach (Common.RagdollPartRefs part in Features.Player.Ragdoll.Parts)
            {
                part.TapCatcher.OnUp += () => Features.Player.OnClickToRagdollPart?.Invoke(part);
            }
        }
    }
}
