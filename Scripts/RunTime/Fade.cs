using UnityEngine;

namespace AnimationPro.RunTime
{
    internal class FadeImpl : ContentTransform
    {
        private float lastFrameRatio;
        private readonly bool isIn;

        public FadeImpl(RateSpec a, bool isIn) : base(a)
        {
            this.isIn = isIn;
        }
        
        public override TransitionSpec OnInitialized()
        {
            return new TransitionSpec(alpha: isIn ? 0f : 1f);
        }

        public override TransitionSpec OnUpdate(float frame)
        {
            var currentFrameRatio = RateSpec.GetRate(frame);
            var diff = currentFrameRatio - lastFrameRatio;

            // Store the current value for the next frame
            lastFrameRatio = currentFrameRatio;

            // Return the difference
            return new TransitionSpec(alpha: isIn ? diff : -diff);
        }
    }
}