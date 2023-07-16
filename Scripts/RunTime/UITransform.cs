using System;
using UnityEngine;
using UnityEngine.UI;

namespace AnimationPro.RunTime
{
    [AddComponentMenu("AnimationPro/UI/UITransform"),
    RequireComponent(typeof(RectTransform))]
    public class UITransform : AnimationCore
    {
        private RectTransform rectTransform;
        private Graphic[] graphics;


        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            
            graphics = GetComponentsInChildren<Graphic>();
            initAlpha = new float[graphics.Length];
        }
        protected override void UpdateAlpha(float a)
        {
            foreach (var graphic in graphics)
            {
                var color = graphic.color;
                color.a += a;
                if (color.a <= 1.0f && color.a >= 0.0f)
                {
                    graphic.color = color;
                }
            }
        }

        protected override void InitializeParam()
        {
            if (initialized)
            {
                throw new Exception();
            }

            for (var i = 0; i < graphics.Length; i++)
            {
                initAlpha[i] = graphics[i].color.a;
            }

            initPos = rectTransform.localPosition;

            initQuaternion = rectTransform.localRotation;
            
            initialized = true;
        }

        protected override void RevertInitializeParam()
        {
            if (!initialized)
            {
                throw new Exception();
            }

            for (var i = 0; i < graphics.Length; i++)
            {
                var color = graphics[i].color;
                color.a += initAlpha[i];
                graphics[i].color = color;
            }
            
            rectTransform.localPosition = initPos;
            rectTransform.localRotation = initQuaternion;
            
            initialized = false;
        }

        protected override void UpdatePosition(Vector3 pos)
        {
            rectTransform.localPosition += pos;
        }

        protected override void UpdateRotate(Quaternion rot)
        {
            rectTransform.Rotate(rot.x, rot.y, rot.z);
        }

        protected override void SetParam(TransitionSpec a)
        {
            if (a.alpha.HasValue)
            {
                foreach (var graphic in graphics)
                {
                    var color = graphic.color;
                    color.a = a.alpha.Value;
                    graphic.color = color;
                }
            }

            if (a.position.HasValue)
            {
                rectTransform.localPosition = a.position.Value;
            }

            if (a.rotate.HasValue)
            {
                var rot = a.rotate.Value;
                rectTransform.Rotate(rot.x, rot.y, rot.z);
            }
        }

        public Rect GetRect()
        {
            return rectTransform.rect;
        }

        public Vector3 GetLocalPosition()
        {
            return rectTransform.localPosition;
        }

    }
}