using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _GAME.Common
{
    public class ObjectTapCatcher : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        public event Action OnDown;
        public event Action OnUp;
        public event Action OnClick;

        public void OnPointerClick(PointerEventData eventData) => OnClick?.Invoke();
        public void OnPointerDown(PointerEventData eventData) => OnDown?.Invoke();
        public void OnPointerUp(PointerEventData eventData) => OnUp?.Invoke();
    }
}