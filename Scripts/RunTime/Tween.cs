/*
 * Author: Matuyuhi
 * Date: 2023-07-26 (Update: 2023-08-30)
 * File: Tween.cs
 */

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace AnimationPro.RunTime
{
    internal static class Tween
    {
        private static readonly RateSpec DefaultSpec = new(2f);

        public static ContentTransform Fade(
            [CanBeNull] RateSpec a,
            bool isIn
        )
        {
            a ??= DefaultSpec;
            return new FadeImpl(a, isIn);
        }

        public static ContentTransform SlideIn(
            this IAnimation origin,
            [CanBeNull] RateSpec a,
            Vector3 distance
        )
        {
            a ??= DefaultSpec;
            return new SlideImpl(a, -distance, origin.GetLocalPosition() + distance);
        }

        public static ContentTransform SlideOut(
            this IAnimation origin,
            [CanBeNull] RateSpec a,
            Vector3 distance
        )
        {
            a ??= DefaultSpec;
            return new SlideImpl(a, distance);
        }

        public static ContentTransform SlideHorizontal(
            this IAnimation origin,
            bool isIn,
            [CanBeNull] RateSpec a,
            AnimationAPI.DirectionHorizontal direction = AnimationAPI.DirectionHorizontal.Right
        )
        {
            var (canvasRectTransform, canvasCenterPosInCanvas) = origin.GetCommonSlideParts();
            float distance = 0;

            switch (direction)
            {
                case AnimationAPI.DirectionHorizontal.Right:
                    distance = canvasRectTransform.rect.width - (canvasCenterPosInCanvas.x - origin.GetRect().width / 2);
                    break;

                case AnimationAPI.DirectionHorizontal.Left:
                    distance = -(canvasCenterPosInCanvas.x + origin.GetRect().width / 2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            a ??= DefaultSpec;
            var targetPosition = new Vector3(distance, 0, 0);
            if (isIn)
            {
                var pos = origin.GetLocalPosition();
                return new SlideImpl(a, -targetPosition, new Vector3(distance, pos.y, pos.z));
            }

            return new SlideImpl(a, targetPosition);
        }

        public static ContentTransform SlideVertical(
            this IAnimation origin,
            bool isIn,
            [CanBeNull] RateSpec a,
            AnimationAPI.DirectionVertical direction = AnimationAPI.DirectionVertical.Up
        )
        {
            var (canvasRectTransform, canvasCenterPosInCanvas) = origin.GetCommonSlideParts();
            float distance = 0;

            switch (direction)
            {
                case AnimationAPI.DirectionVertical.Up:
                    distance = canvasRectTransform.rect.height - (canvasCenterPosInCanvas.y - origin.GetRect().height / 2);
                    break;

                case AnimationAPI.DirectionVertical.Down:
                    distance = -(canvasCenterPosInCanvas.y + origin.GetRect().height / 2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            a ??= DefaultSpec;
            var targetPosition = new Vector3(0, distance, 0);
            if (isIn)
            {
                var pos = origin.GetLocalPosition();
                return new SlideImpl(a, -targetPosition, new Vector3(pos.x, distance, pos.z));
            }

            return new SlideImpl(a, targetPosition);
        }

        public static ContentTransform ScaleTo(
            this IAnimation origin,
            float rate,
            bool isIn,
            [CanBeNull] RateSpec a
        )
        {
            return new ScaleImpl(a, new Vector2(1 - rate, 1 - rate), isIn);
        }
        
        public static ContentTransform ScaleTo(
            this IAnimation origin,
            Vector2 rate,
            bool isIn,
            [CanBeNull] RateSpec a
        )
        {
            rate.x = 1 - rate.x;
            rate.y = 1 - rate.y;
            return new ScaleImpl(a, rate, isIn);
        }
        
        public static ContentTransform ScaleFrom(
            this IAnimation origin,
            float rate,
            [CanBeNull] RateSpec a
        )
        {
            return new ScaleImpl(a, new Vector2(rate, rate),　true);
        }

        private static (RectTransform, Vector2) GetCommonSlideParts(this IAnimation origin)
        {
            var canvasRectTransform = origin.GetRootRect();

            if (canvasRectTransform == null) throw new Exception("UITransform must be a child of a Canvas.");

            var canvasCenterPosInCanvas = new Vector2(
                canvasRectTransform.rect.width / 2 + origin.GetLocalPosition().x,
                canvasRectTransform.rect.height / 2 + origin.GetLocalPosition().y
            );

            return (canvasRectTransform, canvasCenterPosInCanvas);
        }
    }
}