using UnityEngine;

namespace AnimationPro.RunTime
{
    public class TransitionSpec
    {
        public TransitionSpec(
            Quaternion? rotate = null,
            Vector3? position = null,
            float? alpha = null,
            float? scale = null
        )
        {
            Position = position;
            Rotate = rotate;
            Alpha = alpha;
            Scale = scale;
        }

        public Quaternion? Rotate { get; }
        public Vector3? Position { get; }
        public float? Alpha { get; }
        
        public float? Scale { get; }
    }

    internal static class TransitionSpecExtensions
    {
        public static TransitionSpec CombineWith(
            this TransitionSpec a,
            TransitionSpec b
        )
        {
            return new TransitionSpec(
                NullableSum(a.Rotate, b.Rotate),
                NullableSum(a.Position, b.Position),
                NullableSum(a.Alpha, b.Alpha),
                NullableSum(a.Scale, a.Scale)
            );
        }

        private static Vector3? NullableSum(Vector3? value1, Vector3? value2)
        {
            if (!value1.HasValue && !value2.HasValue)
                return null;
            if (!value1.HasValue)
                return value2.Value;
            if (!value2.HasValue)
                return value1.Value;
            return value1.Value + value2.Value;
        }

        private static Quaternion? NullableSum(Quaternion? value1, Quaternion? value2)
        {
            if (!value1.HasValue && !value2.HasValue)
                return null;
            if (!value1.HasValue)
                return value2.Value;
            if (!value2.HasValue)
                return value1.Value;
            return value1.Value * value2.Value; // Quaternionは通常、乗算で結合します。
        }

        private static float? NullableSum(float? value1, float? value2)
        {
            if (!value1.HasValue && !value2.HasValue)
                return null;
            if (!value1.HasValue)
                return value2.Value;
            if (!value2.HasValue)
                return value1.Value;
            return value1.Value + value2.Value;
        }
    }
}