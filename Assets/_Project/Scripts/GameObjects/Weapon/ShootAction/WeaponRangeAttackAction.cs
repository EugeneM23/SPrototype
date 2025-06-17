using UnityEngine;

namespace Gameplay
{
    public class WeaponRangeAttackAction : WeaponShootComponent.IAction
    {
        private CharacterStats _stats;

        private readonly RangedWeaponConfig _config;

        void WeaponShootComponent.IAction.Invoke()
        {
            _stats.CharacterEntity.Get<Animator>().SetFloat("AttackSpeed", GetAnimationTime());
            _stats.CharacterEntity.Get<Animator>().CrossFade("RangeAttack", 0.25f);
        }

        public WeaponRangeAttackAction(CharacterStats stats, RangedWeaponConfig config)
        {
            _stats = stats;
            _config = config;
        }

        private float GetAnimationTime()
        {
            RuntimeAnimatorController controller = _stats.CharacterEntity.Get<Animator>().runtimeAnimatorController;

            foreach (AnimationClip clip in controller.animationClips)
            {
                if (clip.name == "RangeAttack")
                {
                    float baseMultiplier = clip.length / _config.fireRate;
                    float finalMultiplier = baseMultiplier * (1 + _stats.FireRateMultiplier / 100f);
                    return finalMultiplier;
                }
            }

            return 1;
        }
    }
}