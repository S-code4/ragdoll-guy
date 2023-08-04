using UnityEngine;

namespace _GAME.Player
{
    public class RestartButtonLogic : MonoBehaviour
    {
        private void Awake()
        {
            Features.Level.RestartButton.TapCatcher.OnUp += () => Features.Level.OnLevelToDefault?.Invoke();
            Features.Level.RestartButton.TapCatcher.OnUp += TempDisableToButton;
        }

        private void TempDisableToButton()
        {
            Features.Level.RestartButton.Collider.enabled = false;
            this.DelayedCall(2, () => Features.Level.RestartButton.Collider.enabled = true);
        }
    }
}
