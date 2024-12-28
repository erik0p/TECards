using ModdingUtils.MonoBehaviours;
using UnityEngine;
using TECards.MonoBehaviours;
using TECards.RoundsEffects;
using UnboundLib.GameModes;
using System.Collections.Generic;
using System.Collections;

namespace TECards.MonoBehaviours
{
    public class SCP035EffectProxy : CounterReversibleEffect
    {
        private bool effectIsActive;
        private bool applyDamageBuff = true;
        private float elapsedTime = 0.0f;
        private float interval = 8.0f;

        public override CounterStatus UpdateCounter()
        {
            if (effectIsActive)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= interval)
                {
                    applyDamageBuff = !applyDamageBuff;
                    elapsedTime %= interval;
                }
                return CounterStatus.Apply;
            } else
            {
                return CounterStatus.Wait;
            }
        }

        public override void UpdateEffects()
        {
            //this.gunStatModifier.damage_add = 1.0f;
            //this.gunAmmoStatModifier.reloadTimeMultiplier_mult = 0.25f;
            //this.characterStatModifiersModifier.movementSpeed_mult = 1.75f;
            //this.characterDataModifier.numberOfJumps_add = 1;
            //this.gunStatModifier.projectileColor = Color.red;
            if (applyDamageBuff)
            {
                this.gunStatModifier.damage_add = 1f;
                this.gunStatModifier.attackSpeed_mult = 1f;
                this.gunAmmoStatModifier.reloadTimeMultiplier_mult = 1f;
                this.characterStatModifiersModifier.movementSpeed_mult = 1f;
                this.characterDataModifier.numberOfJumps_add = 0;
                this.gunStatModifier.projectileColor = Color.red;
            }
            else
            {
                this.gunStatModifier.damage_add = 0f;
                this.gunStatModifier.attackSpeed_mult = 0.4f;
                this.gunAmmoStatModifier.reloadTimeMultiplier_mult = 0.25f;
                this.characterStatModifiersModifier.movementSpeed_mult = 1.75f;
                this.characterDataModifier.numberOfJumps_add = 1;
                this.gunStatModifier.projectileColor = Color.cyan;
            }
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
