namespace AnimationPro.RunTime
{
    public sealed class AnimationSpec
    {
        public float DurationMilliSec { get; private set; }
        public float WaitMilliSec { get; private set; }

        public AnimationSpec(
            float durationMilliSec = 0f, 
            float waitMilliSec = 0f
        )
        {
            DurationMilliSec = durationMilliSec;
            WaitMilliSec = waitMilliSec;
        }

        public float GetRatio(float frame)
        {
            if (frame >= DurationMilliSec + WaitMilliSec)
            {
                return 1.0f;
            }

            if (frame <= WaitMilliSec)
            {
                return 0.0f;
            }

            return (frame - WaitMilliSec) / DurationMilliSec;
        }
    }
}