using UnityEngine;

namespace AnimationPro.RunTime
{
    internal enum SlideLine
    {
        
    }
    internal class SlideImpl : ContentTransform
    {
        private readonly Vector3 distance;
        private float lastFrameRatio;
        public SlideImpl(AnimationSpec a, Vector3 distance) : base(a)
        {
            this.distance = distance;
        }

        public override TransitionSpec OnUpdate(float frame)
        {
            var currentFrameRatio = AnimationSpec.GetRatio(frame);
            var diff = currentFrameRatio - lastFrameRatio;
            lastFrameRatio = currentFrameRatio;
            return new TransitionSpec(position: distance * diff);
        }
    }
}