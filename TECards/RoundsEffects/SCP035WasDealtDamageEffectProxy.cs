using UnboundLib;
using UnityEngine;
using TECards.MonoBehaviours;

namespace TECards.RoundsEffects
{
    public class SCP035WasDealtDamageEffectProxy : WasDealtDamageEffect
    {
        public override void WasDealtDamage(Vector2 damage, bool selfDamage)
        {
            Player playerToApplyEffect = this.gameObject.GetComponent<Player>().data.lastSourceOfDamage;
            SCP035EffectProxy selfEffect = this.gameObject.GetComponent<Player>().gameObject.GetComponent<SCP035EffectProxy>();
            if (!selfDamage && playerToApplyEffect != null && this.gameObject.GetComponent<Player>().data.health <= 0 && selfEffect != null && selfEffect.IsActive())
            {
                if (playerToApplyEffect.gameObject.GetComponent<SCP035Effect>() == null)
                {
                    SCP035EffectProxy reversibleEffect = playerToApplyEffect.gameObject.GetOrAddComponent<SCP035EffectProxy>();
                    reversibleEffect.UpdateProxyStatus(true);
                }
                if (playerToApplyEffect.gameObject.GetComponent<SCP035WasDealtDamageEffect>() == null)
                {
                    SCP035WasDealtDamageEffectProxy wasDealtDamageEffect = playerToApplyEffect.gameObject.GetOrAddComponent<SCP035WasDealtDamageEffectProxy>();
                }
            }
        }
    }
}
