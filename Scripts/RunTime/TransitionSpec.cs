using UnityEngine;


namespace AnimationPro.RunTime
{
    public class TransitionSpec
    {
        public Quaternion rotate;
        public Vector3 position;
        public float alpha;
        public TransitionSpec(
            Quaternion rotate = new(), 
            Vector3 position = new(),
            float alpha = 0.0f
        )
        {
            this.position = position;
            this.rotate = rotate;
            this.alpha = alpha;
        }

        
    }
    
    internal static class TransitionSpecExtensions
    {
        public static TransitionSpec CombineWith(
            this TransitionSpec a,
            TransitionSpec b
        )
        {
            return new TransitionSpec(a.rotate, a.position + b.position, a.alpha + b.alpha);
        }
    }
}