using UnityEngine;

namespace Gameplay
{
    public class WeaponRangeAttackAction : WeaponShootComponent.IAction
    {
        private CharacterStats _stats;

        private readonly RangedWeaponConfig _config;

        void WeaponShootComponent.IAction.Invoke()
        {
            _stats.CharacterEntity.Get<Animator>().SetFloat("AttackSpeed", GetAnimatTime());
            _stats.CharacterEntity.Get<Animator>().Play("RangeAttack", 0);
        }

        public WeaponRangeAttackAction(CharacterStats stats, RangedWeaponConfig config)
        {
            _stats = stats;
            _config = config;
        }

        private float GetAnimatTime()
        {
            RuntimeAnimatorController controller = _stats.CharacterEntity.Get<Animator>().runtimeAnimatorController;

            foreach (AnimationClip clip in controller.animationClips)
            {
                if (clip.name == "MelleAttack")
                {
                    float baseMultiplier = clip.length / _config.fireRate;
                    float finalMultiplier = baseMultiplier * (1 + _stats.FireRateMultupleyer / 100f);
                    return finalMultiplier;
                }
            }

            return 1;
        }
    }
}