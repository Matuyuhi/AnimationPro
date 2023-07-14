using UnityEngine;

namespace AnimationPro.RunTime
{
    internal class FadeImpl : ContentTransform
    {
        private float beforeRatio;
        private float lastFrameRatio;

        public FadeImpl(AnimationSpec a, bool isIn) : base(a)
        {
            beforeRatio = isIn ? 1f : 0f;
            lastFrameRatio = beforeRatio;
        }

        public override TransitionSpec OnUpdate(float frame)
        {
            var currentFrameRatio = AnimationSpec.GetRatio(frame);
            var diff = currentFrameRatio - lastFrameRatio;
        
            // 今回の値を記憶しておく
            lastFrameRatio = currentFrameRatio;

            // 差分を返す
            return new TransitionSpec(alpha: diff);
        }
    }
}