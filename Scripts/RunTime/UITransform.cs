using System;
using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.UI;

namespace AnimationPro.RunTime
{
    [AddComponentMenu("AnimationPro/UI/UITransform"),
    RequireComponent(typeof(RectTransform))]
    public class UITransform : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Graphic[] graphics;

        [CanBeNull] private IAnimationListener listener;
        
        private float[] initAlpha;
        private Vector3 initPos;
        private Quaternion initQuaternion;
        private bool initialized = false;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            
            graphics = GetComponentsInChildren<Graphic>();
            initAlpha = new float[graphics.Length];
        }

        public void Animation(
            ContentTransform a, 
            [CanBeNull] AnimationListener animationListener = null
        )
        {
            listener = animationListener ?? null;
            InitializeParam();
            StartCoroutine(MoveToCoroutine(a));
        }

        private IEnumerator MoveToCoroutine(ContentTransform a)
        {
            float time = 0f;
            listener?.OnStart();

            while (time < a.maxDuration)
            {
                time += Time.deltaTime;
                var update = a.OnUpdate(time);
                SetAlpha(update.alpha);
                SetRotate(update.rotate);
                SetPosition(update.position);
                yield return null;
            }
            
            RevertInitializeParam();
            listener?.OnFinished();
        }

        private void SetAlpha(float a)
        {
            foreach (var graphic in graphics)
            {
                var color = graphic.color;
                color.a += a;
                graphic.color = color;
            }
        }

        private void InitializeParam()
        {
            if (initialized) throw new Exception();

            for (var i = 0; i < graphics.Length; i++)
            {
                initAlpha[i] = graphics[i].color.a;
            }

            initPos = rectTransform.localPosition;

            initQuaternion = rectTransform.localRotation;
            
            initialized = true;
        }

        private void RevertInitializeParam()
        {
            if (!initialized) throw new Exception();

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

        private void SetPosition(Vector3 pos)
        {
            rectTransform.localPosition += pos;
        }

        private void SetRotate(Quaternion rot)
        {
            rectTransform.Rotate(rot.x, rot.y, rot.z);
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