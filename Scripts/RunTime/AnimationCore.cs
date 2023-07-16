using System;
using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

namespace AnimationPro.RunTime
{
    public abstract class AnimationCore: MonoBehaviour
    {
        protected IAnimationListener listener;
        protected float[] initAlpha;
        protected Vector3 initPos;
        protected Quaternion initQuaternion;
        protected bool initialized = false;

        public void Animation(ContentTransform a, [CanBeNull] AnimationListener animationListener = null)
        {
            listener = animationListener ?? null;
            InitializeParam();
            StartCoroutine(MoveToCoroutine(a));
        }

        private IEnumerator MoveToCoroutine(ContentTransform a)
        {
            float time = 0f;
            listener?.OnStart();
            SetParam(a.OnInitialized());

            while (time < a.maxDuration)
            {
                time += Time.deltaTime;
                var update = a.OnUpdate(time);
                OnUpdate(update);
               
                yield return null;
            }

            RevertInitializeParam();
            listener?.OnFinished();
        }

        private void OnUpdate(TransitionSpec update)
        {
            if (update.alpha.HasValue)
            {
                UpdateAlpha(update.alpha.Value);
            }

            if (update.rotate.HasValue)
            {
                UpdateRotate(update.rotate.Value);
            }

            if (update.position.HasValue)
            {
                UpdatePosition(update.position.Value);
            }

        }

        protected abstract void UpdateAlpha(float a);
        protected abstract void UpdateRotate(Quaternion rot);
        protected abstract void UpdatePosition(Vector3 pos);

        protected abstract void SetParam(TransitionSpec a);

        protected abstract void InitializeParam();
        protected abstract void RevertInitializeParam();
    }
}