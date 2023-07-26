/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: RateSpec.cs
 */

namespace AnimationPro.RunTime
{
    internal delegate float RateCall(float rate);

    /// <summary>
    /// These are the parameters that make the animation work
    /// </summary>
    public class RateSpec
    {
        private readonly RateCall callback;

        internal RateSpec(
            RateCall rateCall,
            float durationSec = 0f,
            float waitSec = 0f
        )
        {
            DurationSec = durationSec;
            WaitSec = waitSec;
            callback = rateCall;
        }

        internal RateSpec(
            float durationSec = 0f,
            float waitSec = 0f
        )
        {
            DurationSec = durationSec;
            WaitSec = waitSec;
            callback = rate => rate;
        }

        public float DurationSec { get; }
        public float WaitSec { get; }

        internal float GetRate(float frame)
        {
            if (frame >= DurationSec + WaitSec) return 1.0f;
            if (frame <= WaitSec) return 0.0f;

            var rate = callback.Invoke((frame - WaitSec) / DurationSec);

            return rate;
        }
    }
}