using UnityEngine;
using Zenject;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "ProtectionShield", menuName = "Installers/Ability/ProtectionShield")]
    public class ProtectionShieldInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ProtectionSieldView _shieldPrefab;

        [Inject] private readonly Entity _characterEntity;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ProtectionSieldView>().FromComponentInNewPrefab(_shieldPrefab)
                .UnderTransform(_characterEntity.transform).AsSingle().NonLazy();
        }
    }
}