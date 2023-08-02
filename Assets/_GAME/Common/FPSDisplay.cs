using UnityEngine;
using DG.Tweening;

namespace _GAME.FPS
{
    public class FPSDisplay : MonoBehaviour
    {
        [SerializeField] private bool show;
        [SerializeField] private bool setTo60FPS;

        private float deltaTime;

        private void Start()
        {
            DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(1000, 1000);

            if (setTo60FPS)
                Application.targetFrameRate = 60;

            Input.multiTouchEnabled = false;
        }

        private void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        }

        private void OnGUI()
        {
            if (!show)
                return;

            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(w / 2, 50, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = Color.green;
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            string text = string.Format(" ({1:0.} fps)", msec, fps);
            GUI.Label(rect, text, style);
        }
    }
}