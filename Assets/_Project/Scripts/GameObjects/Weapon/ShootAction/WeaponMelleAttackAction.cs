using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponMelleAttackAction : WeaponShootComponent.IAction
    {
        private CharacterStats _stats;

        private readonly MeleeWeaponConfig _config;

        void WeaponShootComponent.IAction.Invoke()
        {
            _stats.CharacterEntity.Get<Animator>().SetFloat("AttackSpeed", GetAnimatTime());
            _stats.CharacterEntity.Get<Animator>().Play("MeleeAttack", 0);
        }

        public WeaponMelleAttackAction(CharacterStats stats, MeleeWeaponConfig config)
        {
            _stats = stats;
            _config = config;
        }

        private float GetAnimatTime()
        {
            RuntimeAnimatorController controller = _stats.CharacterEntity.Get<Animator>().runtimeAnimatorController;

            foreach (AnimationClip clip in controller.animationClips)
            {
                if (clip.name == "MeleeAttack")
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