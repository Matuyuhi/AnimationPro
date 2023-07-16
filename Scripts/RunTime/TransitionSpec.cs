using UnityEngine;


namespace AnimationPro.RunTime
{
    public class TransitionSpec
    {
        public Quaternion? rotate = null;
        public Vector3? position = null;
        public float? alpha = null;
        public TransitionSpec(
            Quaternion? rotate = null, 
            Vector3? position = null,
            float? alpha = null
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