using JetBrains.Annotations;
using UnityEngine;

namespace AnimationPro.RunTime
{
    /// <summary>
    /// Animations List
    /// </summary>
    public static class AnimationAPI
    {
        public enum SlideDirection
        {
            Horizontal,
            Vertical
        }

        public enum DirectionVertical
        {
            Up,
            Down,
        }

        public enum DirectionHorizontal
        {
            Left,
            Right
        }
        
        public static ContentTransform FadeIn(
            this UITransform origin,
            AnimationSpec a = null
        )
        {
            return Tween.Fade(a, true);
        }
        
        public static ContentTransform FadeOut(
            this UITransform origin,
            AnimationSpec a = null
        )
        {
            return Tween.Fade(a, false);
        }


        public static ContentTransform SlideInHorizontal(
            this UITransform origin, 
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideInHorizontal(DirectionHorizontal.Right, a);
        }
        public static ContentTransform SlideInHorizontal(
            this UITransform origin,
            DirectionHorizontal direction,
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideHorizontal(true, a, direction);
        }
        
        public static ContentTransform SlideOutHorizontal(
            this UITransform origin, 
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideOutHorizontal(DirectionHorizontal.Right, a);
        }
        public static ContentTransform SlideOutHorizontal(
            this UITransform origin, 
            DirectionHorizontal direction,
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideHorizontal(false, a, direction);
        }

        public static ContentTransform SlideInVertical(
            this UITransform origin,
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideInVertical(DirectionVertical.Up, a);
        }

        public static ContentTransform SlideInVertical(
            this UITransform origin,
            DirectionVertical direction,
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideVertical(true, a, direction);
        }
        
        public static ContentTransform SlideOutVertical(
            this UITransform origin, 
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideOutVertical(DirectionVertical.Up, a);
        }
        public static ContentTransform SlideOutVertical(
            this UITransform origin, 
            DirectionVertical direction,
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideVertical(false, a, direction);
        }


        public static ContentTransform SlideTo(
            this UITransform origin,
            Vector2 distance,
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideOut(a, new Vector3(distance.x, distance.y, 0f));
        }
        public static ContentTransform SlideTo(
            this UITransform origin,
            float distance,
            SlideDirection direction,
            [CanBeNull] AnimationSpec a = null
        )
        {
            if (direction == SlideDirection.Horizontal)
            {
                return origin.SlideOut(a, new Vector3(distance, 0f, 0f));
            }
            return origin.SlideOut(a, new Vector3(0f, distance, 0f));
        }
        public static ContentTransform SlideFrom(
            this UITransform origin,
            Vector2 distance,
            [CanBeNull] AnimationSpec a = null
        )
        {
            return origin.SlideIn(a, new Vector3(distance.x, distance.y, 0f));
        }
        public static ContentTransform SlideFrom(
            this UITransform origin,
            float distance,
            SlideDirection direction,
            [CanBeNull] AnimationSpec a = null
        )
        {
            if (direction == SlideDirection.Horizontal)
            {
                return origin.SlideIn(a, new Vector3(distance, 0f, 0f));
            }
            return origin.SlideIn(a, new Vector3(0f, distance, 0f));
        }
    }
}