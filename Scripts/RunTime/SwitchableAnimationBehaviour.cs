/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: SwitchableAnimation.cs
 */
using UnityEngine;
using UnityEngine.UI;

namespace AnimationPro.RunTime
{
    /// <summary>
    /// switch toggle animations state component
    /// </summary>
    public abstract class SwitchableAnimationBehaviour : MonoBehaviour, IAnimation
    {
        private bool state;
        /// <summary>
        /// animation started if this state changed
        /// </summary>
        public bool State
        {
            get => state;
            set
            {
                if (value == state) return;
                state = value;
                DidStateChange();
            }
        }

        public abstract ContentTransform EnterTransform { get; set; }
        
        public abstract ContentTransform ExitTransform { get; set; }
        
        
        private AnimationCore core;

        
        private RectTransform rectTransform;
        private Graphic[] graphics;
        private float[] initAlpha;
        private Vector3 initPos;
        private Quaternion initQuaternion;

        private bool doAnimate;

        private bool waitNextState;


        protected virtual void Awake()
        {

            core = new AnimationCore(this)
            {
                OnUpdate = OnUpdate,
                OnStart =  OnStart,
                OnFinished = OnFinished,
                OnSetParam = OnSetParam
            };

            rectTransform = GetComponent<RectTransform>();

            graphics = GetComponentsInChildren<Graphic>();
            initAlpha = new float[graphics.Length];
            InitializeParam();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void DidStateChange()
        {
            if (!doAnimate)
            {
                if ((state ? EnterTransform : ExitTransform) != null)
                {
                    core.Animation(state ? EnterTransform : ExitTransform);
                }
            }
            else
            {
                waitNextState = true;
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

        public RectTransform GetRootRect()
        {
            return GetComponentInParent<Canvas>()?.GetComponent<RectTransform>();
        }
        
        private void OnUpdate(TransitionSpec update)
        {
            if (update.Alpha.HasValue) UpdateAlpha(update.Alpha.Value);

            if (update.Rotate.HasValue) UpdateRotate(update.Rotate.Value);

            if (update.Position.HasValue) UpdatePosition(update.Position.Value);
        }

        private void OnStart()
        {
            doAnimate = true;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void OnFinished()
        {
            doAnimate = false;
            if (!state)
            {
                RevertInitializeParam();
            }

            if (waitNextState)
            {
                waitNextState = false;
                DidStateChange();
            }
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
            for (var i = 0; i < graphics.Length; i++)
            {
                initAlpha[i] = graphics[i].color.a;
            }

            initPos = rectTransform.localPosition;

            initQuaternion = rectTransform.localRotation;
        }
        


        private void RevertInitializeParam()
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
            {
                foreach (var graphic in graphics)
                {
                    var color = graphic.color;
                    color.a = a.Alpha.Value;
                    graphic.color = color;
                }
            }

            if (a.Position.HasValue)
            {
                rectTransform.localPosition = a.Position.Value;
            }

            if (a.Rotate.HasValue)
            {
                var rot = a.Rotate.Value;
                rectTransform.Rotate(rot.x, rot.y, rot.z);
            }
        }
    }
}