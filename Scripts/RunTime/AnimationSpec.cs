namespace AnimationPro.RunTime
{
    public sealed class AnimationSpec
    {
        public readonly float durationMilliSec;
        public readonly float waitMilliSec;

        public AnimationSpec(
            float durationMilliSec = 0f, 
            float waitMilliSec = 0f
        )
        {
            this.durationMilliSec = durationMilliSec;
            this.waitMilliSec = waitMilliSec;
        }

        public float GetRatio(float frame)
        {
            if (frame >= durationMilliSec + waitMilliSec)
            {
                return 1.0f;
            }

            if (frame <= waitMilliSec)
            {
                return 0.0f;
            }

            return (frame - waitMilliSec) / durationMilliSec;
        }
    }
}