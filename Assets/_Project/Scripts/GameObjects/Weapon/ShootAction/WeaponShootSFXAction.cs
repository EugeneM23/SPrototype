using AudioEngine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponShootSFXAction : IInitializable, WeaponShootComponent.IAction
    {
        private readonly Transform _firePoint;
        private readonly AudioEventKey _key;

        private AudioSystem _audioSystem;

        public WeaponShootSFXAction(Transform firePoint, AudioEventKey key)
        {
            _firePoint = firePoint;
            _key = key;
        }

        public void Initialize() => _audioSystem = AudioSystem.Instance;

        public void Invoke()
        {
            Debug.Log("asdasd");
            _audioSystem.PlayEvent(_key, _firePoint.position, _firePoint.rotation, 0.05f);
        }
    }
}