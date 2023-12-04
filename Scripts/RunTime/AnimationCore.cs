/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: AnimationCore.cs
 */

using System;
using System.Collections;
using UnityEngine;

namespace AnimationPro.RunTime
{
    internal class AnimationCore: AnimationCoreListenerAction
    {

        private readonly MonoBehaviour monoBehaviour;
        private IAnimationCoreListener animationCoreListenerImplementation;

        public AnimationCore(MonoBehaviour monoBehaviour, IAnimationCoreListener listener) : base(listener)
        {
            this.monoBehaviour = monoBehaviour;
        }

        public Coroutine Animation(ContentTransform a)
        {
            a.Init();
            return monoBehaviour.StartCoroutine(MoveToCoroutine(a));
        }

        private IEnumerator MoveToCoroutine(ContentTransform a)
        {
            var time = 0f;
            OnStart();
            OnSetParam(a.OnInitialized());

            while (time < a.MaxDuration)
            {
                time += Time.unscaledDeltaTime;
                var update = a.OnUpdate(time);
                OnUpdate(update);

                yield return null;
            }
            
            OnFinished();
        }
    }
    internal class AnimationCoreListenerAction
    {
        public Action<TransitionSpec> OnUpdate { get; set; }
        public Action<TransitionSpec> OnSetParam { get; set; }
        public Action OnFinished { get; set; }
        public Action OnStart { get; set; }

        public AnimationCoreListenerAction(IAnimationCoreListener listener)
        {
            // Bind the interface methods to our Action delegates
            OnUpdate = listener.OnUpdate;
            OnSetParam = listener.OnSetParam;
            OnFinished = listener.OnFinished;
            OnStart = listener.OnStart;
        }
    }
}