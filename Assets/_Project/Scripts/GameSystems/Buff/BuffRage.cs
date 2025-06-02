using UnityEngine;

namespace Gameplay
{
    public class BuffRage : BaseBuff
    {
        private RageUI rageUI;
        private float speedPerStack;
        private float fireRatePerStack;

        public override void Configure(BuffConfig config)
        {
            base.Configure(config);

            speedPerStack = statValues[BuffMultiplayerID.Speed];
            fireRatePerStack = statValues[BuffMultiplayerID.Speed];
        }

        protected override void ApplyEffects()
        {
            target.Get<IMove>().AddSpeed(speedPerStack);
            target.Get<CharacterStats>().FireRateMultupleyer -= fireRatePerStack;
        }

        protected override void RemoveEffects()
        {
            target.Get<IMove>().AddSpeed(-speedPerStack * stackCount);
            target.Get<CharacterStats>().FireRateMultupleyer += fireRatePerStack * stackCount;
        }

        protected override void ApplyStackEffect()
        {
            target.Get<IMove>().AddSpeed(speedPerStack);
            target.Get<CharacterStats>().FireRateMultupleyer -= fireRatePerStack;
        }

        protected override void CreateUI()
        {
            if (ui != null) 
                rageUI = target.Get<GameFactory>().Create(ui).GetComponent<RageUI>();
        }

        protected override void UpdateUI()
        {
            if (rageUI != null && isTimed)
            {
                float remainingTime = duration - (Time.time - startTime);
                rageUI.UpdateSlider(remainingTime, duration);
            }
        }

        protected override void UpdateStackUI()
        {
            rageUI?.UpdateStack(stackCount);
        }

        protected override void DestroyUI()
        {
            rageUI?.GetComponent<Entity>()?.Dispose();
        }
    }
}