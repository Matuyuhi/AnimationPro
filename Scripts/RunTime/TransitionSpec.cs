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
            return new TransitionSpec(
            NullableSum(a.rotate, b.rotate),
            NullableSum(a.position, b.position), 
            NullableSum(a.alpha, b.alpha)
            );
        }
        public static Vector3? NullableSum(Vector3? value1, Vector3? value2)
        {
            if (!value1.HasValue && !value2.HasValue)
            {
                return null;
            }
            else if (!value1.HasValue)
            {
                return value2.Value;
            }
            else if (!value2.HasValue)
            {
                return value1.Value;
            }
            else
            {
                return value1.Value + value2.Value;
            }
        }

        public static Quaternion? NullableSum(Quaternion? value1, Quaternion? value2)
        {
            if (!value1.HasValue && !value2.HasValue)
            {
                return null;
            }
            else if (!value1.HasValue)
            {
                return value2.Value;
            }
            else if (!value2.HasValue)
            {
                return value1.Value;
            }
            else
            {
                return value1.Value * value2.Value; // Quaternionは通常、乗算で結合します。
            }
        }

        public static float? NullableSum(float? value1, float? value2)
        {
            if (!value1.HasValue && !value2.HasValue)
            {
                return null;
            }
            else if (!value1.HasValue)
            {
                return value2.Value;
            }
            else if (!value2.HasValue)
            {
                return value1.Value;
            }
            else
            {
                return value1.Value + value2.Value;
            }
        }
    }
}