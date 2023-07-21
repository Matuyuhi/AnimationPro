using System;
using System.Collections;
using JetBrains.Annotations;
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
            return monoBehaviour.StartCoroutine(MoveToCoroutine(a));
        }

        private IEnumerator MoveToCoroutine(ContentTransform a)
        {
            var time = 0f;
            onStart?.Invoke();
            onSetParam(a.OnInitialized());

            while (time < a.MaxDuration)
            {
                time += Time.deltaTime;
                var update = a.OnUpdate(time);
                onUpdate(update);

                yield return null;
            }
            
            onFinished?.Invoke();
        }
    }

    internal abstract class CoreListener
    {
        public Action<TransitionSpec> onUpdate;
        public Action<TransitionSpec> onSetParam;
        public Action onFinished;
        public Action onStart;
    }
}