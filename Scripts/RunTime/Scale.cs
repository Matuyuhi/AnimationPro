/*
 * Author: Matuyuhi
 * Date: 2023-07-26 (Update: 2023-08-30)
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
        private readonly Vector2 targetScale;
        private readonly bool isIn;
        private float lastFrameRatio;

        public ScaleImpl(RateSpec a, Vector2 targetScale, bool isIn) : base(a)
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
            var scale = targetScale;
            scale.x = 1 - scale.x;
            scale.y = 1 - scale.y;
            return new TransitionSpec(scale: isIn ? scale : null);
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