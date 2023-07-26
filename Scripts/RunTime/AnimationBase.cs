/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: AnimationBase.cs
 */

using UnityEngine;
using UnityEngine.UI;

namespace AnimationPro.RunTime
{
    public class AnimationBase : MonoBehaviour, IAnimation
    {

        private RectTransform rectTransform;
        private Graphic[] graphics;
        private float[] initAlpha;
        private Vector3 initPos;
        private Quaternion initQuaternion;
        
        protected virtual void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            graphics = GetComponentsInChildren<Graphic>();
            initAlpha = new float[graphics.Length];
        }
        
        public Rect GetRect()
        {
            return rectTransform.rect;
        }

        public Vector3 GetLocalPosition()
        {
            return rectTransform.localPosition;
        }

        public RectTransform GetRootRect()
        {
            return GetComponentInParent<Canvas>()?.GetComponent<RectTransform>();
        }
        
        protected void OnUpdate(TransitionSpec update)
        {
            if (update.Alpha.HasValue) UpdateAlpha(update.Alpha.Value);

            if (update.Rotate.HasValue) UpdateRotate(update.Rotate.Value);

            if (update.Position.HasValue) UpdatePosition(update.Position.Value);
            
            if (update.Scale.HasValue) UpdateScale(update.Scale.Value);
        }
        
        private void UpdateAlpha(float a)
        {
            foreach (var graphic in graphics)
            {
                var color = graphic.color;
                color.a += a;
                if (color.a is <= 1.0f and >= 0.0f) graphic.color = color;
            }
        }

        private void UpdateScale(float scale)
        {
            
        }
        
        private void UpdatePosition(Vector3 pos)
        {
            rectTransform.localPosition += pos;
        }

        private void UpdateRotate(Quaternion rot)
        {
            rectTransform.Rotate(rot.x, rot.y, rot.z);
        }

        protected void OnSetParam(TransitionSpec a)
        {
            if (a.Alpha.HasValue)
                foreach (var graphic in graphics)
                {
                    var color = graphic.color;
                    color.a = a.Alpha.Value;
                    graphic.color = color;
                }

            if (a.Position.HasValue) rectTransform.localPosition = a.Position.Value;

            if (a.Rotate.HasValue)
            {
                var rot = a.Rotate.Value;
                rectTransform.Rotate(rot.x, rot.y, rot.z);
            }
        }
        
        protected void InitializeParam()
        {
    

            for (var i = 0; i < graphics.Length; i++)
            {
                initAlpha[i] = graphics[i].color.a;
            }

            initPos = rectTransform.localPosition;

            initQuaternion = rectTransform.localRotation;


        }
        


        protected void RevertInitializeParam()
        {
          

            for (var i = 0; i < graphics.Length; i++)
            {
                var color = graphics[i].color;
                color.a += initAlpha[i];
                graphics[i].color = color;
            }

            rectTransform.localPosition = initPos;
            rectTransform.localRotation = initQuaternion;
        }
        
    }
}