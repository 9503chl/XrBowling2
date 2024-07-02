﻿using System;
using System.Collections;
using UnityEngine;

namespace UnityEngine.UI
{
    public sealed class TweenMove : UITweener
    {
        public Vector2 FromValue = Vector2.one;

        public Vector2 ToValue = Vector2.one;

        private Vector2 GetValue()
        {
            if (rectTransform != null)
            {
                return rectTransform.anchoredPosition;
            }
            else
            {
                return transform.localPosition;
            }
        }

        private void SetValue(Vector2 value)
        {
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = value;
            }
            else
            {
                transform.localPosition = new Vector3(value.x, value.y, transform.localPosition.z);
            }
        }

        protected override void UpdateProgress(float progress)
        {
            SetValue(Vector2.Lerp(FromValue, ToValue, progress));
        }

#if UNITY_EDITOR
        [ContextMenu("Swap 'From' And 'To'")]
        private void SwapValues()
        {
            Vector2 temp = FromValue;
            FromValue = ToValue;
            ToValue = temp;
        }

        private void Reset()
        {
            FromValue = GetValue();
            ToValue = GetValue();
        }
#endif

        public static TweenMove Create(GameObject target, Vector2 fromValue, Vector2 toValue, float duration, TweeningLoopType loopType = TweeningLoopType.Once, TweeningEaseType easeType = TweeningEaseType.Linear)
        {
            if (target != null)
            {
                TweenMove tweener = target.GetComponent<TweenMove>();
                if (tweener == null)
                {
                    tweener = target.AddComponent<TweenMove>();
                }
                else
                {
                    tweener.Stop();
                }
                tweener.FromValue = fromValue;
                tweener.ToValue = toValue;
                tweener.Duration = duration;
                tweener.LoopType = loopType;
                tweener.EaseType = easeType;
                tweener.enabled = true;
                return tweener;
            }
            return null;
        }

        public static TweenMove Play(GameObject target, Vector2 fromValue, Vector2 toValue, float duration, TweeningLoopType loopType = TweeningLoopType.Once, TweeningEaseType easeType = TweeningEaseType.Linear)
        {
            TweenMove tweener = Create(target, fromValue, toValue, duration, loopType, easeType);
            if (tweener != null)
            {
                tweener.PlayForward();
            }
            return tweener;
        }
    }
}
