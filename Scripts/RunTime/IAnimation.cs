using UnityEngine;

namespace AnimationPro.RunTime
{
    public interface IAnimation
    {
        public Rect GetRect();
        public Vector3 GetLocalPosition();

        public RectTransform GetRootRect();
    }
}