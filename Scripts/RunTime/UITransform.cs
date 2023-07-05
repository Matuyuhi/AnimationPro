using UnityEngine;

namespace AnimationPro.RunTime
{
    [AddComponentMenu("AnimationPro/UI/UITransform"),
    RequireComponent(typeof(RectTransform))]
    public class UITransform : MonoBehaviour
    {
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void SetPosition(Vector2 position)
        {
            rectTransform.anchoredPosition = position;
        }
    }
}