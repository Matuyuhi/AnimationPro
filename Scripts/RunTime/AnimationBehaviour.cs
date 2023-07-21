using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace AnimationPro.RunTime
{
    internal interface IAnimationBehaviour
    {
        public void Animation(ContentTransform transform, [CanBeNull] AnimationListener listener = null);
        public void OnCancel();
        public Rect GetRect();
        public Vector3 GetLocalPosition();
    }
    [RequireComponent(typeof(RectTransform))]
    public abstract class AnimationBehaviour : MonoBehaviour, IAnimationBehaviour
    {
        private AnimationCore core;

        
        private RectTransform rectTransform;
        private Graphic[] graphics;
        private float[] initAlpha;
        private Vector3 initPos;
        private Quaternion initQuaternion;
        
        private bool initialized;

        private Coroutine coroutine;

        [CanBeNull] private AnimationListener listener;

        private void Awake()
        {
            core = new AnimationCore(this)
            {
                onUpdate = OnUpdate,
                onStart =  OnStart,
                onFinished = OnFinished,
                onSetParam = OnSetParam
            };

            rectTransform = GetComponent<RectTransform>();

            graphics = GetComponentsInChildren<Graphic>();
            initAlpha = new float[graphics.Length];
            initialized = false;
        }

        public void Animation(ContentTransform a, AnimationListener animationListener = null)
        {
            listener = animationListener;
            coroutine = core.Animation(a);
        }

        public void OnCancel()
        {
            StopCoroutine(coroutine);
            listener?.OnCancel?.Invoke();
        }
        
        public Rect GetRect()
        {
            return rectTransform.rect;
        }

        public Vector3 GetLocalPosition()
        {
            return rectTransform.localPosition;
        }
        
        
        private void OnUpdate(TransitionSpec update)
        {
            if (update.Alpha.HasValue) UpdateAlpha(update.Alpha.Value);

            if (update.Rotate.HasValue) UpdateRotate(update.Rotate.Value);

            if (update.Position.HasValue) UpdatePosition(update.Position.Value);
        }

        private void OnStart()
        {
            InitializeParam();
            if (listener != null) listener.OnStart?.Invoke();
        }

        private void OnFinished()
        {
            RevertInitializeParam();
            listener?.OnFinished?.Invoke();
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
        
        private void InitializeParam()
        {
            if (initialized) throw new ExternalException();

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
            if (!initialized) throw new ExternalException();

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

        private void UpdatePosition(Vector3 pos)
        {
            rectTransform.localPosition += pos;
        }

        private void UpdateRotate(Quaternion rot)
        {
            rectTransform.Rotate(rot.x, rot.y, rot.z);
        }

        private void OnSetParam(TransitionSpec a)
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
    }
}