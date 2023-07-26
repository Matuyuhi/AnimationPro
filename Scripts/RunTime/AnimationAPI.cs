//// edit by matuyuhi
using JetBrains.Annotations;
using UnityEngine;

namespace AnimationPro.RunTime
{
    /// <summary>
    /// AnimationAPI is a class providing a variety of animation motions.
    /// </summary>
    public static class AnimationAPI
    {
        /// <summary>
        /// Enum representing horizontal directions: Left and Right.
        /// </summary>
        public enum DirectionHorizontal
        {
            /// <summary>
            /// Left direction from the player
            /// </summary>
            Left,
            /// <summary>
            /// right direction from the player
            /// </summary>
            Right
        }

        /// <summary>
        /// Enum representing vertical directions: Up and Down.
        /// </summary>
        public enum DirectionVertical
        {
            /// <summary>
            /// upper direction from the player
            /// </summary>
            Up,
            /// <summary>
            /// down direction from the player
            /// </summary>
            Down
        }

        /// <summary>
        /// Enum representing sliding directions: Horizontal(right|left) and Vertical(up|down).
        /// </summary>
        public enum SlideDirection
        {
            /// <summary>
            /// Horizontal(right|left) direction from the player
            /// </summary>
            Horizontal,
            /// <summary>
            /// Vertical(up|down) direction from the player
            /// </summary>
            Vertical
        }

        /// <summary>
        /// Creates a fade in animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform FadeIn(
            this IAnimation origin,
            RateSpec spec = null
        )
        {
            return Tween.Fade(spec, true);
        }
        
        /// <summary>
        /// Creates a fade out animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform FadeOut(
            this IAnimation origin,
            RateSpec spec = null
        )
        {
            return Tween.Fade(spec, false);
        }

        
        /// <summary>
        /// Creates a slide in with horizontal direction animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform SlideInHorizontal(
            this IAnimation origin,
            [CanBeNull] RateSpec spec = null
        )
        {
            return origin.SlideInHorizontal(DirectionHorizontal.Right, spec);
        }

        /// <summary>
        /// Creates a slide in with horizontal direction animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="direction">moving horizontal direction left or right</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform SlideInHorizontal(
            this IAnimation origin,
            DirectionHorizontal direction,
            [CanBeNull] RateSpec spec = null
        )
        {
            return origin.SlideHorizontal(true, spec, direction);
        }

        /// <summary>
        /// Creates a slide out with horizontal direction animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform SlideOutHorizontal(
            this IAnimation origin,
            [CanBeNull] RateSpec spec= null
        )
        {
            return origin.SlideOutHorizontal(DirectionHorizontal.Right, spec);
        }

        /// <summary>
        /// Creates a slide out with horizontal direction animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="direction">moving horizontal direction left or right</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform SlideOutHorizontal(
            this IAnimation origin,
            DirectionHorizontal direction,
            [CanBeNull] RateSpec spec= null
        )
        {
            return origin.SlideHorizontal(false, spec, direction);
        }

        
        /// <summary>
        /// Creates a slide in with vertical direction animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform SlideInVertical(
            this IAnimation origin,
            [CanBeNull] RateSpec spec= null
        )
        {
            return origin.SlideInVertical(DirectionVertical.Up, spec);
        }

        /// <summary>
        /// Creates a slide in with vertical direction animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="direction">moving vertical direction up or down</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform SlideInVertical(
            this IAnimation origin,
            DirectionVertical direction,
            [CanBeNull] RateSpec spec= null
        )
        {
            return origin.SlideVertical(true, spec, direction);
        }

        /// <summary>
        /// Creates a slide out with vertical direction animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform SlideOutVertical(
            this IAnimation origin,
            [CanBeNull] RateSpec spec= null
        )
        {
            return origin.SlideOutVertical(DirectionVertical.Up, spec);
        }
        
        /// <summary>
        /// Creates a slide out with vertical direction animation on the given object.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="direction">moving vertical direction up or down</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the FadeIn animation movement.</returns>
        public static ContentTransform SlideOutVertical(
            this IAnimation origin,
            DirectionVertical direction,
            [CanBeNull] RateSpec spec= null
        )
        {
            return origin.SlideVertical(false, spec, direction);
        }
        
        
        /// <summary>
        /// Animates the given object to slide to a specific Vector2 distance.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="distance">The Vector2 distance to slide to.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the SlideTo animation movement.</returns>
        public static ContentTransform SlideTo(
            this IAnimation origin,
            Vector2 distance,
            [CanBeNull] RateSpec spec= null
        )
        {
            return origin.SlideOut(spec, new Vector3(distance.x, distance.y, 0f));
        }

        /// <summary>
        /// Animates the given object to slide to a specific distance in the specified direction.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="distance">The distance to slide to.</param>
        /// <param name="direction">The direction of the slide animation.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the SlideTo animation movement.</returns>
        public static ContentTransform SlideTo(
            this IAnimation origin,
            float distance,
            SlideDirection direction,
            [CanBeNull] RateSpec spec= null
        )
        {
            if (direction == SlideDirection.Horizontal) return origin.SlideOut(spec, new Vector3(distance, 0f, 0f));
            return origin.SlideOut(spec, new Vector3(0f, distance, 0f));
        }

        
        /// <summary>
        /// Animates the given object to slide from a specific Vector2 distance.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="distance">The Vector2 distance to slide from.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the SlideFrom animation movement.</returns>
        public static ContentTransform SlideFrom(
            this IAnimation origin,
            Vector2 distance,
            [CanBeNull] RateSpec spec= null
        )
        {
            return origin.SlideIn(spec, new Vector3(distance.x, distance.y, 0f));
        }

        /// <summary>
        /// Animates the given object to slide from a specific distance in the specified direction.
        /// </summary>
        /// <param name="origin">The object to animate.</param>
        /// <param name="distance">The distance to slide from.</param>
        /// <param name="direction">The direction of the slide animation.</param>
        /// <param name="spec">Easing function to define animation's pace over time.</param>
        /// <returns>Returns the SlideFrom animation movement.</returns>
        public static ContentTransform SlideFrom(
            this IAnimation origin,
            float distance,
            SlideDirection direction,
            [CanBeNull] RateSpec spec= null
        )
        {
            if (direction == SlideDirection.Horizontal) return origin.SlideIn(spec, new Vector3(distance, 0f, 0f));
            return origin.SlideIn(spec, new Vector3(0f, distance, 0f));
        }
    }
}