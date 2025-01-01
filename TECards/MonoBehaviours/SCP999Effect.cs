using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class SCP999Effect : TimedReversibleEffect
    {
        ReversibleColorEffect colorEffect;

        public override void OnStart()
        {
            base.OnStart();
            duration = 5.0f;
            characterStatModifiersModifier.movementSpeed_mult = 0.8f;
            gunAmmoStatModifier.reloadTimeMultiplier_mult = 1.4f;
            gunStatModifier.attackSpeed_mult = 1.4f;

            colorEffect = player.gameObject.GetOrAddComponent<ReversibleColorEffect>();
            colorEffect.SetColor(new Color(1f, 0.65f, 0f)); // Orange

            player.data.stats.WasDealtDamageAction += OnDamage;
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            ApplyModifiers();
        }

        public override void OnOnDestroy()
        {
            base.OnOnDestroy();
            Destroy(colorEffect);
            player.data.stats.WasDealtDamageAction -= OnDamage;
        }

        public void ResetTimer()
        {
            duration = 4.0f;
        }

        private void OnDamage(Vector2 damage, bool selfDamage)
        {
            Player playerToApplyEffect = player.data.lastSourceOfDamage;
            if (!selfDamage && playerToApplyEffect != null)
            {
                playerToApplyEffect.data.healthHandler.Heal(damage.magnitude * 0.5f);
            }
        }
    }
}
