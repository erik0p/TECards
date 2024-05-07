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
        private GunStatModifier gunStatsToModify;

        private float timeOfLastbulllet;
        private float baseSpread;
        public override void OnAwake()
        {
            base.OnAwake();
            this.playerToModify = gameObject.GetComponent<Player>();
            this.gunToModify = playerToModify.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.baseSpread = gunToModify.spread;

            GameObject attackTrigger = new GameObject("MOZEM_A");
            AttackTrigger trigger = attackTrigger.AddComponent<AttackTrigger>();
            trigger.triggerEvent = new UnityEngine.Events.UnityEvent();
            trigger.triggerEvent.AddListener(() =>
            {
                UnityEngine.Debug.Log($"{gunToModify.timeBetweenBullets} time between bullets");
                UnityEngine.Debug.Log($"{Time.time - timeOfLastbulllet} time difference");
                if (Time.time - timeOfLastbulllet <= 0.2f)
                {
                    gunToModify.spread -= 0.02f;
                    if (gunToModify.spread < 0)
                    {
                        gunToModify.spread = 0;
                    }
                }
                else
                {
                    gunToModify.spread = baseSpread;
                }
                UnityEngine.Debug.Log($"spread={gunToModify.spread}");
                timeOfLastbulllet = Time.time;
            });
            attackTrigger.transform.parent = playerToModify.transform;
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Time.time - timeOfLastbulllet > 0.2f)
            {
                gunToModify.spread = baseSpread;
            } 
        }
    }
}
