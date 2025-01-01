using ModdingUtils.MonoBehaviours;

namespace TECards.MonoBehaviours
{
    public class RedCandyEffect : CounterReversibleEffect
    {
        private float duration;
        private float regenAmount;

        public override void OnStart()
        {
            base.OnStart();
            ResetTimer();
        }
        public override void OnApply()
        {
        }

        public override void Reset()
        {
            ResetTimer();
        }

        public override CounterStatus UpdateCounter()
        {
            duration -= TimeHandler.deltaTime;
            if (duration > 0) 
            {
                regenAmount = 10f;
            } else
            {
                regenAmount = 0f;
            }
            return CounterStatus.Apply;
        }

        public override void UpdateEffects()
        {
            health.regeneration = regenAmount;
        }

        public void ResetTimer()
        {
            duration = 30f;
        }
    }
}
