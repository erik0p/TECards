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
        private float regenBonus;
        private float elapsedTime = 0f;
        private float interval = 1f;

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
            elapsedTime += TimeHandler.deltaTime;
            if (IsPlayerMoving(currLoc, prevLoc))
            {
                regenBonus = 0f;

                elapsedTime = 0f;
            } 
            else if (elapsedTime >= interval)
            {
                regenBonus = 12f;
            }

            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            base.healthHandlerModifier.regen_add = regenBonus;
        }
        private bool IsPlayerMoving(Vector2 curr, Vector2 prev)
        {
            return Vector2.Distance(curr, prev) > 0.01;
        }
    }
}
