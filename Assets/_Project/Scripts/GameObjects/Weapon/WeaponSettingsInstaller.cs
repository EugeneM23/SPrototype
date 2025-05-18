using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class WeaponSettingsInstaller : MonoInstaller
    {
        [SerializeField] private float fireRate;
        [SerializeField] private float scatter;
        [SerializeField] private float fireRange;
        [SerializeField] private int damage;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float ShakeDuration;
        [SerializeField] private float shakeMagnitude;
        [SerializeField] private float shellImpulse;
        [SerializeField] private float recoilPower;
        [SerializeField] private int projectileCount;
        [SerializeField] private int maxRicochetCount;

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId(WeaponParameterID.FireRate).FromInstance(fireRate).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.Scatter).FromInstance(scatter).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.FireRange).FromInstance(fireRange).AsCached();
            Container.Bind<int>().WithId(WeaponParameterID.Damage).FromInstance(damage).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.BulletSpeed).FromInstance(bulletSpeed).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.ShakeDuration).FromInstance(ShakeDuration).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.ShakeMagnitude).FromInstance(shakeMagnitude).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.ShellImpulse).FromInstance(shellImpulse).AsCached();
            Container.Bind<float>().WithId(WeaponParameterID.RecoilPower).FromInstance(recoilPower).AsCached();
            Container.Bind<int>().WithId(WeaponParameterID.ProjectileCount).FromInstance(projectileCount).AsCached();
            Container.Bind<int>().WithId(WeaponParameterID.MaxRicochetCount).FromInstance(maxRicochetCount).AsCached();
        }
    }
}