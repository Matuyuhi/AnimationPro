using UnityEngine;
using UnityEngine.EventSystems;

namespace AnimationPro.RunTime
{
    [RequireComponent(typeof(RectTransform)), AddComponentMenu("AnimationPro/UI/SlideWithPointer")]
    public class AnimatedSlidePointer : SwitchableAnimationBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public override ContentTransform EnterTransform { get; set; }
        public override ContentTransform ExitTransform { get; set; }
        [SerializeField] private Vector2 distance = new(50f, 0f);
        [SerializeField] private float delaySec = 0.3f;

        private void Start()
        {
            EnterTransform = this.SlideTo(distance, Easings.QuartOut(delaySec));
            ExitTransform = this.SlideFrom(distance, Easings.QuartIn(delaySec));
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