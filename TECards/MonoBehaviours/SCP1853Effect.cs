using ModdingUtils.MonoBehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class SCP1853Effect : CounterReversibleEffect
    {
        private int stacks;

        public override void OnStart()
        {
            base.OnStart();
            stacks = 0;
            player.data.stats.WasDealtDamageAction += OnDamage;
        }
        public override void OnApply()
        {
        }

        public override void Reset()
        {
            stacks = 0;
        }

        public override CounterStatus UpdateCounter()
        {
            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            this.gunStatModifier.attackSpeed_mult = 1f - (stacks * 0.15f);
            this.gunAmmoStatModifier.reloadTimeMultiplier_mult = 1f - (stacks * 0.15f);
            this.characterStatModifiersModifier.movementSpeed_mult = 1f + (stacks * 0.15f);
        }

        public override void OnOnDestroy()
        {
            base.OnOnDestroy();
            player.data.stats.WasDealtDamageAction -= OnDamage;
        }

        private void OnDamage(Vector2 damage, bool selfDamage)
        {
            if (!selfDamage && stacks < 4)
            {
                stacks++;
            }
        }
    }
}
