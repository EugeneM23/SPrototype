using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class WeaponMelleSettingsInstaller : MonoInstaller
    {
        [SerializeField] private float _attackrate;
        [SerializeField] private float _damageCastDelay;
        [SerializeField] private int _damage;
        [SerializeField] private float _range;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeMagnitude;

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId(WeaponParameterID.FireRate).FromInstance(_attackrate).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.DamageCastDelay).FromInstance(_damageCastDelay).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.FireRange).FromInstance(_range).AsCached();
            Container.Bind<int>().WithId(WeaponParameterID.Damage).FromInstance(_damage).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.ShakeDuration).FromInstance(_shakeDuration).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.ShakeMagnitude).FromInstance(_shakeMagnitude).AsCached();
        }
    }
}