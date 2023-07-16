namespace AnimationPro.RunTime
{
    public abstract class ContentTransform
    {
        protected AnimationSpec AnimationSpec { get; set; }
        public float maxDuration;

        protected ContentTransform(AnimationSpec a)
        {
            AnimationSpec = a;
            maxDuration = a.durationMilliSec + a.waitMilliSec;
        }

        protected ContentTransform(AnimationSpec a, float maxDuration)
        {
            AnimationSpec = a;
            this.maxDuration = maxDuration;
        }

        public abstract TransitionSpec OnUpdate(float frame);

        public abstract TransitionSpec OnInitialized();
        
        public static ContentTransform operator +(ContentTransform a, ContentTransform b)
        {
            var composite = new CompositeContentTransform(new AnimationSpec(0f, 0f));
            composite.AddAnimation(a);
            composite.AddAnimation(b);
            return composite;
        }
    }
}