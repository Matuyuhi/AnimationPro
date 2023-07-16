using System.Collections.Generic;

namespace AnimationPro.RunTime
{
    public class CompositeContentTransform : ContentTransform
    {
        private readonly List<ContentTransform> animations = new ();

        public CompositeContentTransform(AnimationSpec a) : base(a) {}

        public void AddAnimation(ContentTransform animation)
        {
            animations.Add(animation);
 
            // 必要に応じて最大時間を更新する
            if (animation.MaxDuration > MaxDuration)
            {
                SetMaxDuration(animation.MaxDuration);
            }
        }

        public override TransitionSpec OnInitialized()
        {
            TransitionSpec result = new TransitionSpec();
            foreach (ContentTransform animation in animations)
            {
                result = result.CombineWith(animation.OnInitialized());
            }
            return result;
        }

        public override TransitionSpec OnUpdate(float frame)
        {
            TransitionSpec result = new TransitionSpec();
            foreach (ContentTransform animation in animations)
            {
                result = result.CombineWith(animation.OnUpdate(frame));
            }
            
            return result;
        }
    
        public static CompositeContentTransform operator +(CompositeContentTransform a, ContentTransform b)
        {
            a.AddAnimation(b);
            return a;
        }
    }
}