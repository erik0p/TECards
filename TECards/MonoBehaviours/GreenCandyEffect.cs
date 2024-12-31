using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModdingUtils;
using ModdingUtils.MonoBehaviours;

namespace TECards.MonoBehaviours
{
    public class GreenCandyEffect : CounterReversibleEffect
    {
        private float regenAmount;
        public override void OnApply()
        {
        }

        public override void Reset()
        {
        }

        public override CounterStatus UpdateCounter()
        {
            if (player.data.block.IsOnCD())
            {
                regenAmount = 4f;
            } else
            {
                regenAmount = 0f;
            }

            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            healthHandlerModifier.regen_add = regenAmount;
        }
    }
}
