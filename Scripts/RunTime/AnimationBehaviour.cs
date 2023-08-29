/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: AnimationBehaviour.cs
 */

using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;


namespace AnimationPro.RunTime
{
    internal interface IAnimationBehaviour
    {
        public void Animation(ContentTransform transform, [CanBeNull] AnimationListener listener = null);
        public void OnCancel();
    }
    
    [RequireComponent(typeof(RectTransform))]
    public abstract class AnimationBehaviour : AnimationBase, IAnimationBehaviour, IAnimationCoreListener
    {
        private AnimationCore core;
        
        
        private bool initialized;

        public bool IsAnimate => coroutine != null;

        private Coroutine coroutine;

        [CanBeNull] private AnimationListener listener;

        protected override void Awake()
        {
            base.Awake();
            core = new AnimationCore(this, this);
            initialized = false;
        }

        public void Animation(ContentTransform a, AnimationListener animationListener = null)
        {
            listener = animationListener;
            coroutine = core.Animation(a);
        }

        public void OnCancel()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                listener?.OnCancel?.Invoke();
            }
        }


        public override void OnStart()
        {
            InitializeParam();
            initialized = true;
            if (listener != null) listener.OnStart?.Invoke();
        }

        public override void OnFinished()
        {
            coroutine = null;
            RevertInitializeParam();
            listener?.OnFinished?.Invoke();
        }
    }
}