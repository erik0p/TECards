using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModdingUtils;
using ModdingUtils.MonoBehaviours;

namespace TECards.MonoBehaviours
{
    public class YellowCandyEffect : CounterReversibleEffect
    {
        private float duration;
        private float multiplier;

        public override void OnStart()
        {
            base.OnStart();
            ResetTimer();
        }
        public override void OnApply()
        {
        }

        public override void Reset()
        {
            ResetTimer();
        }

        public override CounterStatus UpdateCounter()
        {
            duration -= TimeHandler.deltaTime;
            if (duration > 0) 
            {
                multiplier = 1.5f;
            } else
            {
                multiplier = 1f;
            }
            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            characterStatModifiersModifier.movementSpeed_mult = multiplier;
        }

        public void ResetTimer()
        {
            duration = 30f;
        }
    }

}
