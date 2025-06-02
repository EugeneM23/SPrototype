using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponMelleAttackAction : WeaponShootComponent.IAction
    {
        private CharacterStats _stats;

        [Inject(Id = WeaponParameterID.FireRate)]
        private float _fireRate;

        void WeaponShootComponent.IAction.Invoke()
        {
            _stats.CharacterEntity.Get<Animator>().SetFloat("AttackSpeed", GetAnimatTime());
            _stats.CharacterEntity.Get<Animator>().Play("MelleAttack", 0);
        }

        public WeaponMelleAttackAction(CharacterStats stats)
        {
            _stats = stats;
        }

        private float GetAnimatTime()
        {
            RuntimeAnimatorController controller = _stats.CharacterEntity.Get<Animator>().runtimeAnimatorController;

            foreach (AnimationClip clip in controller.animationClips)
            {
                if (clip.name == "MelleAttack")
                {
                    Debug.Log(clip.length / _fireRate);
                    float baseMultiplier = clip.length / _fireRate;
                    float finalMultiplier = baseMultiplier * (1 + _stats.FireRateMultupleyer / 100f);
                    return finalMultiplier;
                }
            }

            return 1;
        }
    }
}