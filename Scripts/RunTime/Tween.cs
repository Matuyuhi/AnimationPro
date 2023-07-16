
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace AnimationPro.RunTime
{
    internal static class Tween
    {
        private static readonly AnimationSpec defalutSpec = new(2f, 0f);
        public static ContentTransform Fade(
            [CanBeNull] AnimationSpec a, 
            bool isIn
        )
        {
            a ??= defalutSpec;
            return new FadeImpl(a, isIn);
        }

        public static ContentTransform SlideIn(
            this UITransform origin,
            [CanBeNull] AnimationSpec a, 
            Vector3 distance
        )
        {
            a ??= defalutSpec;
            return new SlideImpl(a, origin.GetLocalPosition() - distance, distance);
        }

        public static ContentTransform SlideOut(
            this UITransform origin,
            [CanBeNull] AnimationSpec a, 
            Vector3 distance
        )
        {
            a ??= defalutSpec;
            return new SlideImpl(a, distance);
        }
        
        public static ContentTransform SlideHorizontal(
            this UITransform origin, 
            bool isIn,
            [CanBeNull] AnimationSpec a, 
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

            a ??= defalutSpec;
            Vector3 targetPosition = new Vector3(distance, 0, 0);
            if (isIn)
            {
                var pos = origin.GetLocalPosition();
                return new SlideImpl(a, -targetPosition, new Vector3(distance, pos.y, pos.z));
            }
            return new SlideImpl(a, targetPosition);
        }

        public static ContentTransform SlideVertical(
            this UITransform origin, 
            bool isIn,
            [CanBeNull] AnimationSpec a,
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

            a ??= defalutSpec;
            Vector3 targetPosition = new Vector3(0, distance, 0);
            if (isIn)
            {
                var pos = origin.GetLocalPosition();
                return new SlideImpl(a, -targetPosition, new Vector3(pos.x, distance, pos.z));
            }
            return new SlideImpl(a, targetPosition);
        }
        
        private static (RectTransform, Vector2) GetCommonSlideParts(this UITransform origin)
        {
            RectTransform canvasRectTransform = origin.GetComponentInParent<Canvas>()?.GetComponent<RectTransform>();

            if (canvasRectTransform == null)
            {
                throw new Exception("UITransform must be a child of a Canvas.");
            }

            Vector2 canvasCenterPosInCanvas = new Vector2(
                canvasRectTransform.rect.width / 2 + origin.GetLocalPosition().x,
                canvasRectTransform.rect.height / 2 + origin.GetLocalPosition().y
            );

            return (canvasRectTransform, canvasCenterPosInCanvas);
        }
    }
}