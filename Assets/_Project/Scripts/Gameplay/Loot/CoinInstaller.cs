using UnityEngine;
using Zenject;

namespace Gameplay.Loot
{
    public class CoinInstaller : MonoInstaller
    {
        [SerializeField] private int _rotationSpeed;
        [SerializeField] private Transform _coinPrefab;

        public override void InstallBindings()
        {
        }
    }
}