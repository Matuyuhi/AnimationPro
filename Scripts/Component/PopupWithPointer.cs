/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: AnimatedSlidePointer.cs
 */

using AnimationPro.RunTime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AnimationPro.Component
{
    [RequireComponent(typeof(RectTransform)), AddComponentMenu("AnimationPro/UI/PopupWithPointer")]
    public class PopupWithPointer : SwitchableAnimationBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public override ContentTransform EnterTransform { get; set; }
        public override ContentTransform ExitTransform { get; set; }
        [SerializeField] private float rate = 1.2f;
        [SerializeField] private float delaySec = 0.3f;

        private void Start()
        {
            EnterTransform = this.ScaleOut(rate, Easings.QuartOut(delaySec));
            ExitTransform = this.ScaleIn(2 - rate, Easings.QuartIn(delaySec));
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            State = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            State = false;
        }
    }
}