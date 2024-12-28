using ModdingUtils.MonoBehaviours;
using System.Collections;
using UnboundLib.GameModes;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class SCP035Effect : CounterReversibleEffect
    {

        public override CounterStatus UpdateCounter()
        {
            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            this.gunStatModifier.damage_mult = 2.0f;
            this.gunAmmoStatModifier.reloadTimeMultiplier_mult = 0.25f;
            this.characterStatModifiersModifier.movementSpeed_mult = 1.75f;
            this.characterDataModifier.numberOfJumps_add = 1;
            this.gunStatModifier.projectileColor = Color.red;
        }

        public override void OnApply()
        {
        }

        public override void Reset()
        {
        }
        public static IEnumerator SCP035Hook(IGameModeHandler gameModeHandler)
        {
            foreach (var player in PlayerManager.instance.players)
            {
                SCP035EffectProxy effect = player.gameObject.GetComponent<SCP035EffectProxy>();
                if (effect != null)
                {
                    effect.DisableEffect();
                }
            }
            yield break;
        }
    }
}
