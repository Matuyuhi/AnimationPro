/*
 * Author: Matuyuhi
 * Date: 2023-07-26
 * File: AnimationListener.cs
 */

using System;

namespace AnimationPro.RunTime
{
    public interface IAnimationListener
    {
        void OnStart();
        void OnCancel();
        void OnFinished();
    }

    public class AnimationListener : IAnimationListener
    {
        public Action OnStart { get; set; }
        public Action OnCancel { get; set; }
        public Action OnFinished { get; set; }

        void IAnimationListener.OnStart()
        {
            OnStart?.Invoke();
        }

        void IAnimationListener.OnCancel()
        {
            OnCancel?.Invoke();
        }

        void IAnimationListener.OnFinished()
        {
            OnFinished?.Invoke();
        }
    }

    // public delegate int UIACallback();
}