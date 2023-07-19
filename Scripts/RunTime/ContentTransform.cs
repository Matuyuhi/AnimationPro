namespace AnimationPro.RunTime
{
    public abstract class ContentTransform
    {
        protected RateSpec RateSpec { get; set; }
        public float MaxDuration { get; private set; }

        protected ContentTransform(RateSpec a)
        {
            RateSpec = a;
            MaxDuration = a.DurationSec + a.WaitSec;
        }

        protected ContentTransform(RateSpec a, float maxDuration)
        {
            RateSpec = a;
            MaxDuration = maxDuration;
        }

        public abstract TransitionSpec OnUpdate(float frame);

        public abstract TransitionSpec OnInitialized();
        
        public static ContentTransform operator +(ContentTransform a, ContentTransform b)
        {
            var composite = new CompositeContentTransform(new RateSpec(0f, 0f));
            composite.AddAnimation(a);
            composite.AddAnimation(b);
            return composite;
        }

        protected void SetMaxDuration(float duration)
        {
            MaxDuration = duration;
        }
    }
}