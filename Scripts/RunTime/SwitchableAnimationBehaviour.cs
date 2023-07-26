/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: SwitchableAnimationBehaviour.cs
 */

namespace AnimationPro.RunTime
{
    /// <summary>
    /// switch toggle animations state component
    /// </summary>
    public abstract class SwitchableAnimationBehaviour : AnimationBase, IAnimationCoreListener
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

        private bool doAnimate;

        private bool waitNextState;


        protected override void Awake()
        {
            base.Awake();
            core = new AnimationCore(this, this)
            {
                OnUpdate = OnUpdate,
                OnStart =  OnStart,
                OnFinished = OnFinished,
                OnSetParam = OnSetParam
            };
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

        public override void OnStart()
        {
            doAnimate = true;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void OnFinished()
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
    }
}