namespace AnimationPro.RunTime
{
    /// <summary>
    /// animation base class
    /// </summary>
    public abstract class ContentTransform
    {
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

        protected RateSpec RateSpec { get; }
        public float MaxDuration { get; private set; }

        public abstract void Init();

        public abstract TransitionSpec OnUpdate(float frame);

        public abstract TransitionSpec OnInitialized();

        public static ContentTransform operator +(ContentTransform a, ContentTransform b)
        {
            var composite = new CompositeContentTransform(new RateSpec());
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