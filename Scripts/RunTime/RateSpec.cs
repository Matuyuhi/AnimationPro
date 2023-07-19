namespace AnimationPro.RunTime
{
    internal delegate float RateCall(float rate);
    public class RateSpec
    {
        public float DurationSec { get; }
        public float WaitSec { get; }

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

        internal float GetRate(float frame)
        {
            if (frame >= DurationSec + WaitSec) { return 1.0f; }
            if (frame <= WaitSec) { return 0.0f; }

            var rate = callback.Invoke((frame - WaitSec) / DurationSec);

            return rate;
        }
        
    }
}