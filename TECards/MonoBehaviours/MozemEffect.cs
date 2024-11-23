using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class MozemEffect : ReversibleEffect
    {
        private Player playerToModify;
        private Gun gunToModify;

        private float timeOfLastbulllet;
        private float baseSpread;
        private int maxAmmo;
        public override void OnAwake()
        {
            base.OnAwake();
            this.playerToModify = gameObject.GetComponent<Player>();
            this.gunToModify = playerToModify.GetComponent<Holding>().holdable.GetComponent<Gun>();

            GameObject attackTrigger = new GameObject("MOZEM_A");
            AttackTrigger trigger = attackTrigger.AddComponent<AttackTrigger>();
            trigger.triggerEvent = new UnityEngine.Events.UnityEvent();
            trigger.triggerEvent.AddListener(() =>
            {
                UnityEngine.Debug.Log($"{gunToModify.attackSpeed} atk speed");
                UnityEngine.Debug.Log($"{gunToModify.timeBetweenBullets} time between bullets");
                UnityEngine.Debug.Log($"{Time.time - timeOfLastbulllet} time difference");
                UnityEngine.Debug.Log($"{gunToModify.attackSpeed + (gunToModify.attackSpeed * 0.4)} max time diff");
                if (Time.time - timeOfLastbulllet <= gunToModify.attackSpeed + (gunToModify.attackSpeed * 0.4))
                {
                    //gunToModify.spread -= (baseSpread / (maxAmmo / 2));
                    gunStatModifier.evenSpread_add = -(baseSpread / (maxAmmo / 2));
                    UnityEngine.Debug.Log($"spread decrease={gunToModify.spread / (maxAmmo / 2)}");
                    UnityEngine.Debug.Log($"ammo={maxAmmo}");
                    //if (gunToModify.spread < 0)
                    //{
                    //    gunToModify.spread = 0;
                    //}
                    gunStatModifier.ApplyGunStatModifier(gunToModify);
                    //if (gunToModify.spread < 0)
                    //{
                    //}
                }
                else
                {
                    //gunToModify.spread = baseSpread;
                    //gunStatModifier.SetFieldValue("Spread", baseSpread);
                    ClearModifiers();
                }
                UnityEngine.Debug.Log($"spread={gunToModify.spread}");
                timeOfLastbulllet = Time.time;
            });
            attackTrigger.transform.parent = playerToModify.transform;
        }

        public override void OnStart()
        {
            base.OnStart();
            this.baseSpread = gunToModify.spread;
            this.maxAmmo = playerToModify.data.weaponHandler.gun.GetComponentInChildren<GunAmmo>().maxAmmo;
        }

        public void OnUpdate()
        {
            base.OnUpdate();
            if (Time.time - timeOfLastbulllet > gunToModify.attackSpeed + (gunToModify.attackSpeed * 0.4))
            {
                //gunToModify.spread = baseSpread;
                //gunStatModifier.SetFieldValue("Spread", baseSpread);
                ClearModifiers();
            } 
        }
    }
}
