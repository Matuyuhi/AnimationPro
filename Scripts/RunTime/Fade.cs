namespace AnimationPro.RunTime
{
    /// <summary>
    /// Fade system in AnimationAPi
    /// </summary>
    internal class FadeImpl : ContentTransform
    {
        private readonly bool isIn;
        private float lastFrameRatio;

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