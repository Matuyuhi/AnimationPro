/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: SlideImpl.cs
 */

using UnityEngine;

namespace AnimationPro.RunTime
{
    internal class SlideImpl : ContentTransform
    {
        private readonly Vector3 distance;
        private readonly Vector3? initPos;
        private float lastFrameRatio;

        public SlideImpl(RateSpec a, Vector3 distance, Vector3? initPos = null) : base(a)
        {
            this.initPos = initPos;
            this.distance = distance;
        }

        public override void Init()
        {
            lastFrameRatio = 0f;
        }

        public override TransitionSpec OnInitialized()
        {
            return new TransitionSpec(position: initPos.HasValue ? initPos.Value : null);
        }

        public override TransitionSpec OnUpdate(float frame)
        {
            var currentFrameRatio = RateSpec.GetRate(frame);
            var diff = currentFrameRatio - lastFrameRatio;
            lastFrameRatio = currentFrameRatio;
            return new TransitionSpec(position: distance * diff);
        }
    }
}