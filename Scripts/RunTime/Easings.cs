using System;

namespace AnimationPro.RunTime
{
    public static class Easings
    {
        public static RateSpec Default(float delaySec, float waitSec = 0f)
        {
            return new RateSpec(delaySec, waitSec);
        }

        public static RateSpec BounceOut(float delaySec, float waitSec = 0f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => (float)BounceEnded(x)
            );
        }

        public static RateSpec BounceIn(float delaySec, float waitSec = 0f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => 1 - (float)BounceEnded(1 - x)
            );
        }

        public static RateSpec BackInOut(float delaySec, float waitSec = 0f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => (float)StartEndBack(x)
            );
        }

        public static RateSpec BackIn(float delaySec, float waitSec = 0f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => (float)StartBack(x)
            );
        }

        public static RateSpec BackOut(float delaySec, float waitSec = 0f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => (float)EndBack(x)
            );
        }

        public static RateSpec QuartIn(float delaySec, float waitSec = 0f, float quartRate = 1f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => (float)EndedQuart(x, quartRate)
            );
        }

        public static RateSpec QuartOut(float delaySec, float waitSec = 0f, float quartRate = 1f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => 1f - (float)EndedQuart(1f - x, quartRate)
            );
        }

        public static RateSpec QuartInOut(float delaySec, float waitSec = 0f, float quartRate = 1f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => (float)InOutQuart(x)
            );
        }

        private static double InOutQuart(float x, float rate = 1f)
        {
            return x < 0.5 ? 8 * x * x * x * x : 1 - Math.Pow(-2 * x + 2, 4) / 2;
        }

        public static RateSpec CircIn(float delaySec, float waitSec = 0f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => 1f - (float)Math.Sqrt(1 - Math.Pow(x, 2))
            );
        }

        public static RateSpec CircOut(float delaySec, float waitSec = 0f)
        {
            return new RateSpec(
                durationSec: delaySec,
                waitSec: waitSec,
                rateCall: x => (float)Math.Sqrt(1 - Math.Pow(x - 1, 2))
            );
        }


        private static double EndedQuart(float x, float rate)
        {
            return Math.Pow(x, rate * 4);
        }

        private static double StartEndBack(float x)
        {
            const double c1 = 1.70158;
            const double c2 = c1 * 1.525;

            return x < 0.5
                ? Math.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2) / 2
                : (Math.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        }

        private static double StartBack(float x)
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1;

            return c3 * x * x * x - c1 * x * x;
        }

        private static double EndBack(float x)
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1;

            return 1 + c3 * Math.Pow(x - 1, 3) + c1 * Math.Pow(x - 1, 2);
        }

        private static double BounceEnded(float x)
        {
            const double n1 = 7.5625;
            const double d1 = 2.75;

            if (x < 1 / d1) return n1 * x * x;
            if (x < 2 / d1) return n1 * (x -= (float)(1.5 / d1)) * x + 0.75;
            if (x < 2.5 / d1) return n1 * (x -= (float)(2.25 / d1)) * x + 0.9375;
            return n1 * (x -= (float)(2.625 / d1)) * x + 0.984375;
        }
    }
}