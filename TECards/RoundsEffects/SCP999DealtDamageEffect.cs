using UnboundLib;
using UnityEngine;
using ModdingUtils.RoundsEffects;
using TECards.MonoBehaviours;

namespace TECards.RoundsEffects
{
    public class SCP999DealtDamageEffect : HitEffect
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer = null)
        {
            if (damagedPlayer != null)
            {
                SCP999Effect effect = damagedPlayer.gameObject.GetComponent<SCP999Effect>();
                if (effect != null)
                {
                    effect.ResetTimer();
                } 
                else
                {
                    effect = damagedPlayer.gameObject.GetOrAddComponent<SCP999Effect>();
                }
            }
        }
    }
}
