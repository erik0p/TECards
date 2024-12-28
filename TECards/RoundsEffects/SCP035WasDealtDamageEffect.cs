using ModdingUtils.RoundsEffects;
using UnboundLib;
using UnityEngine;
using TECards.MonoBehaviours;

namespace TECards.RoundsEffects
{
    public class SCP035WasDealtDamageEffect : WasDealtDamageEffect
    {
        public override void WasDealtDamage(Vector2 damage, bool selfDamage)
        {
            Player playerToApplyEffect = this.gameObject.GetComponent<Player>().data.lastSourceOfDamage;
            if (!selfDamage && playerToApplyEffect != null && this.gameObject.GetComponent<Player>().data.health <= 0)
            {
                if (playerToApplyEffect.gameObject.GetComponent<SCP035Effect>() == null)
                {
                    SCP035EffectProxy reversibleEffect = playerToApplyEffect.gameObject.GetOrAddComponent<SCP035EffectProxy>();
                    reversibleEffect.EnableEffect();
                } else
                {
                    UnityEngine.Debug.Log("cant add effect already have");
                }
                SCP035WasDealtDamageEffect wasDealtDamageEffect = playerToApplyEffect.gameObject.GetOrAddComponent<SCP035WasDealtDamageEffect>();
            }
        }
    }
}
