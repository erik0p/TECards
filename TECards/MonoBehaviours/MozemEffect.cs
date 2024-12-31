using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class MozemEffect : CounterReversibleEffect
    {
        private int totalAmmoCount;
        private int currentAmmoCount;
        private float attackSpdMultiplier;
        private float spreadMultiplier;

        public override void OnStart()
        {
            totalAmmoCount = gun.GetComponentInChildren<GunAmmo>().maxAmmo;
            currentAmmoCount = totalAmmoCount;
        }

        public override CounterStatus UpdateCounter()
        {
            GunAmmo currentAmmo = gun.GetComponentInChildren<GunAmmo>();
            attackSpdMultiplier = 1f;
            spreadMultiplier = 1f;
            totalAmmoCount = currentAmmo.maxAmmo;
            currentAmmoCount = (int)currentAmmo.GetFieldValue("currentAmmo");

            if (currentAmmoCount > 0)
            {
                attackSpdMultiplier = UnityEngine.Mathf.Lerp(0.1f, 1f, ((float)currentAmmoCount / (float)totalAmmoCount * 0.5f));
                spreadMultiplier = UnityEngine.Mathf.Lerp(0f, 1f, ((float)currentAmmoCount / (float)totalAmmoCount * 0.75f));
                if (totalAmmoCount == 1)
                {
                    attackSpdMultiplier = 1f;
                    spreadMultiplier = 0f;
                }
            }
            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            gunStatModifier.attackSpeed_mult = attackSpdMultiplier;
            gunStatModifier.spread_mult = spreadMultiplier;
        }

        public override void OnApply()
        {
        }

        public override void Reset()
        {
        }
    }
}
