using UnityEngine;

namespace AnimationPro.RunTime
{
    internal class FadeImpl : ContentTransform
    {
        private float lastFrameRatio;
        private bool isIn;

        public FadeImpl(AnimationSpec a, bool isIn) : base(a)
        {
            this.isIn = isIn;
        }
        
        public override TransitionSpec OnInitialized()
        {
            return new TransitionSpec(alpha: isIn ? 0f : 1f);
        }

        public override TransitionSpec OnUpdate(float frame)
        {
            var currentFrameRatio = AnimationSpec.GetRatio(frame);
            var diff = currentFrameRatio - lastFrameRatio;

            // Store the current value for the next frame
            lastFrameRatio = currentFrameRatio;

            // Return the difference
            return new TransitionSpec(alpha: isIn ? diff : -diff);
        }
    }
}