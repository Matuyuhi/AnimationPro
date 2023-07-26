using System;
using System.Collections;
using UnityEngine;

namespace AnimationPro.RunTime
{
    internal class AnimationCore : CoreListener
    {

        private readonly MonoBehaviour monoBehaviour;

        public AnimationCore(MonoBehaviour monoBehaviour)
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
            OnStart?.Invoke();
            OnSetParam(a.OnInitialized());

            while (time < a.MaxDuration)
            {
                time += Time.deltaTime;
                var update = a.OnUpdate(time);
                OnUpdate(update);

                yield return null;
            }
            
            OnFinished?.Invoke();
        }
    }

    internal abstract class CoreListener
    {
        public Action<TransitionSpec> OnUpdate;
        public Action<TransitionSpec> OnSetParam;
        public Action OnFinished;
        public Action OnStart;
    }
}