using ModdingUtils.MonoBehaviours;
using UnityEngine;
using TECards.MonoBehaviours;
using TECards.RoundsEffects;
using UnboundLib.GameModes;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections;

namespace TECards.MonoBehaviours
{
    public class SCP035EffectProxy : CounterReversibleEffect
    {
        private bool effectIsActive;

        public override CounterStatus UpdateCounter()
        {
            if (effectIsActive)
            {
                return CounterStatus.Apply;
            } else
            {
                return CounterStatus.Wait;
            }
        }

        public override void UpdateEffects()
        {
            this.gunStatModifier.damage_mult = 2.0f;
            this.gunAmmoStatModifier.reloadTimeMultiplier_mult = 0.25f;
            this.characterStatModifiersModifier.movementSpeed_mult = 1.75f;
            this.characterDataModifier.numberOfJumps_add = 1;
            this.gunStatModifier.projectileColor = Color.red;
        }

        public override void OnApply()
        {
        }

        public override void Reset()
        {
        }

        public void EnableEffect()
        {
            this.effectIsActive = true;
        }

        public void DisableEffect()
        {
            this.effectIsActive = false;
        }
    }
}
