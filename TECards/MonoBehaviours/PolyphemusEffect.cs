using ModdingUtils.MonoBehaviours;
using UnboundLib;

namespace TECards.MonoBehaviours
{
    public class PolyphemusEffect : CounterReversibleEffect
    {
        private int totalAmmoCount;
        private int currentAmmoCount;
        private float sizeIncrease;

        public override void OnStart()
        {
            totalAmmoCount = gun.GetComponentInChildren<GunAmmo>().maxAmmo;
            currentAmmoCount = totalAmmoCount;
        }

        public override CounterStatus UpdateCounter()
        {
            GunAmmo currentAmmo = gun.GetComponentInChildren<GunAmmo>();
            sizeIncrease = 0f;
            totalAmmoCount = currentAmmo.maxAmmo;
            currentAmmoCount = (int)currentAmmo.GetFieldValue("currentAmmo");

            if (currentAmmoCount > 0)
            {
                sizeIncrease = UnityEngine.Mathf.Lerp(10f, 0f, ((float)currentAmmoCount / (float)totalAmmoCount));
                if (totalAmmoCount == 1) // give player max size increase if they have 1 max ammo
                {
                    sizeIncrease = 10f;
                }
            }
            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            gunStatModifier.projectileSize_add = sizeIncrease;
        }

        public override void OnApply()
        {
        }

        public override void Reset()
        {
        }
    }
}
