using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class PolyphemusEffect : CounterReversibleEffect
    {
        private int totalAmmoCount;
        private int currentAmmoCount;
        private float multiplier;

        public override void OnStart()
        {
            this.totalAmmoCount =  this.gun.GetComponentInChildren<GunAmmo>().maxAmmo;
            this.currentAmmoCount = totalAmmoCount;
        }

        public override CounterStatus UpdateCounter()
        {
            GunAmmo currentAmmo = this.gun.GetComponentInChildren<GunAmmo>();
            this.multiplier = 0f;
            this.totalAmmoCount = currentAmmo.maxAmmo;
            this.currentAmmoCount = (int)currentAmmo.GetFieldValue("currentAmmo");

            if (this.currentAmmoCount > 0)
            {
                this.multiplier = UnityEngine.Mathf.Lerp(10f, 0f, ((float)this.currentAmmoCount / (float)this.totalAmmoCount));
                if (this.totalAmmoCount == 1)
                {
                    this.multiplier = 1f;
                }
            }
            UnityEngine.Debug.Log($"size mult {multiplier}");
            //gunStatModifier.projectileSize_mult = 1f + (1f * multiplier);
            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            //gun.projectileSize = this.multiplier;
            gunStatModifier.projectileSize_add = this.multiplier;
        }

        public override void OnApply()
        {
        }

        public override void Reset()
        {
        }
    }
}
