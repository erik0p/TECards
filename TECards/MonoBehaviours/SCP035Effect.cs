﻿using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class SCP035Effect : CounterReversibleEffect
    {
        private bool applyDamageBuff;
        private float elapsedTime;
        private float interval = 8.0f;

        public override void OnStart()
        {
            base.OnStart();
            applyDamageBuff = true;
            elapsedTime = 0f;
        }

        public override void Reset()
        {
            applyDamageBuff = true;
            elapsedTime = 0f;
        }

        public override CounterStatus UpdateCounter()
        {
            elapsedTime += TimeHandler.deltaTime;
            if (elapsedTime >= interval) 
            {
                applyDamageBuff = !applyDamageBuff;
                elapsedTime %= interval;
            }
            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
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
    }
}
