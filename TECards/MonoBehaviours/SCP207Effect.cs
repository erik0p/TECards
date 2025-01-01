using UnityEngine;
using ModdingUtils.MonoBehaviours;

namespace TECards.MonoBehaviours
{
    public class SCP207Effect : ReversibleEffect
    {
        private Vector2 prevLoc;
        private Vector2 currLoc;
        private float elapsedTime = 0f;
        private float interval = 0.1f;

        public override void OnStart()
        {
            base.OnStart();
            elapsedTime = 0f;
            SetLivesToEffect(int.MaxValue);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            prevLoc = currLoc;
            currLoc = base.player.transform.position;
            if (IsPlayerMoving(currLoc, prevLoc))
            {
                elapsedTime += TimeHandler.deltaTime;
                if (elapsedTime >= interval)
                {
                    health.TakeDamage(Vector2.up * elapsedTime * 10f, player.transform.position, null, null, false, true);
                    elapsedTime %= interval; 
                }
            }
        }

        private bool IsPlayerMoving(Vector2 curr, Vector2 prev)
        {
            return Vector2.Distance(curr, prev) > 0.01;
        }
    }
}
