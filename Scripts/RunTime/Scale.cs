/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: ScaleImpl.cs
 */

using UnityEngine;

namespace AnimationPro.RunTime
{
    /// <summary>
    /// Fade system in AnimationAPi
    /// </summary>
    internal class ScaleImpl : ContentTransform
    {
        private readonly float targetScale;
        private readonly bool isIn;
        private float lastFrameRatio;

        public ScaleImpl(RateSpec a, float targetScale, bool isIn) : base(a)
        {
            this.isIn = isIn;
            this.targetScale = targetScale;
        }

        public override void Init()
        {
            lastFrameRatio = 0f;
        }

        public override TransitionSpec OnInitialized()
        {
            return new TransitionSpec(scale: isIn ? 1 - targetScale : null);
        }

        public override TransitionSpec OnUpdate(float frame)
        {
            var currentFrameRatio = RateSpec.GetRate(frame);
            var diff = (currentFrameRatio - lastFrameRatio) * targetScale;

            // Store the current value for the next frame
            lastFrameRatio = currentFrameRatio;

            // Return the difference
            return new TransitionSpec(scale: -diff);
        }
    }
}