
using System;
using UnityEngine;

namespace AnimationPro.RunTime
{
    public static class AP
    {
        public static ContentTransform FadeIn(
            this UITransform origin,
            AnimationSpec a = null
        )
        {
            a ??= new AnimationSpec(3f, 0f);
            return new FadeImpl(a, true);
        }
        
        public static ContentTransform FadeOut(
            this UITransform origin,
            AnimationSpec a = null
        )
        {
            a ??= new AnimationSpec(3f, 0f);
            return new FadeImpl(a, false);
        }

        public enum SlideDirection
        {
            Up,
            Down,
            Left,
            Right
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
        
        public static ContentTransform SlideHorizontal(this UITransform origin, AnimationSpec a = null, DirectionHorizontal direction = DirectionHorizontal.Right)
        {
            var (canvasRectTransform, canvasCenterPosInCanvas) = origin.GetCommonSlideParts();
            float distance = 0;

            switch (direction)
            {
                case DirectionHorizontal.Right:
                    distance = canvasRectTransform.rect.width - (canvasCenterPosInCanvas.x - origin.GetRect().width / 2);
                    break;

                case DirectionHorizontal.Left:
                    distance = -(canvasCenterPosInCanvas.x + origin.GetRect().width / 2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            a ??= new AnimationSpec(1f, 0f);
            Vector3 targetPosition = new Vector3(distance, 0, 0);
            return new SlideImpl(a, targetPosition);
        }

        public static ContentTransform SlideVertical(
            this UITransform origin, 
            AnimationSpec a = null,
            DirectionVertical direction = DirectionVertical.Up
        )
        {
            var (canvasRectTransform, canvasCenterPosInCanvas) = origin.GetCommonSlideParts();
            float distance = 0;

            switch (direction)
            {
                case DirectionVertical.Up:
                    distance = canvasRectTransform.rect.height - (canvasCenterPosInCanvas.y - origin.GetRect().height / 2);
                    break;

                case DirectionVertical.Down:
                    distance = -(canvasCenterPosInCanvas.y + origin.GetRect().height / 2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            a ??= new AnimationSpec(1f, 0f);
            Vector3 targetPosition = new Vector3(0, distance, 0);
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
        
        
        public static ContentTransform SlideHorizontal(
            this UITransform origin,
            float distance,
            AnimationSpec a = null
        )
        {
            a ??= new AnimationSpec(1f, 0f);
            return new SlideImpl(a, new Vector3(distance, 0f, 0f));
        }
    }
}