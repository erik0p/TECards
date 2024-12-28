using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class AntiColaEffect : CounterReversibleEffect
    {
        private Vector2 prevLoc;
        private Vector2 currLoc;
        private float multiplier;
        private float elapsedTime = 0.0f;
        private float interval = 2.0f;

        public override void OnApply()
        {
        }

        public override void Reset()
        {
        }

        public override CounterStatus UpdateCounter()
        {
            prevLoc = currLoc;
            currLoc = base.player.transform.position;
            elapsedTime += Time.deltaTime;
            if (IsPlayerMoving(currLoc, prevLoc))
            {
                multiplier = 1f;

                // reset timer
                elapsedTime %= interval;
            } 
            else if (elapsedTime >= interval)
            {
                multiplier = 2f;
            }

            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            base.healthHandlerModifier.regen_mult = multiplier;
        }
        private bool IsPlayerMoving(Vector2 curr, Vector2 prev)
        {
            return Vector2.Distance(curr, prev) > 0.1;
        }
    }
}
