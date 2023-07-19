namespace AnimationPro.RunTime
{
    public class RateSpecBuilder
    {
        private float durationSec;
        private float waitSec;

        public RateSpecBuilder Duration(float durationSec)
        {
            this.durationSec = durationSec;
            return this;
        }

        public RateSpecBuilder Wait(float waitSec)
        {
            this.waitSec = waitSec;
            return this;
        }

        public RateSpec Default()
        {
            return Easings.Default(durationSec, waitSec);
        }

        
        public RateSpec CircOut()
        {
            return Easings.CircOut(durationSec, waitSec);
        }
        
        public RateSpec CircIn()
        {
            return Easings.CircOut(durationSec, waitSec);
        }


        public RateSpec BackIn()
        {
            return Easings.BackIn(durationSec, waitSec);
        }
        
        public RateSpec BackOut()
        {
            return Easings.BackOut(durationSec, waitSec);
        }
        
        public RateSpec BackInOut()
        {
            return Easings.BackInOut(durationSec, waitSec);
        }


        public RateSpec BounceOut()
        {
            return Easings.BounceOut(durationSec, waitSec);
        }
        public RateSpec BounceIn()
        {
            return Easings.BounceIn(durationSec, waitSec);
        }
    }
}