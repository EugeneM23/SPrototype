using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyReasonerControllInstaller", menuName = "Installers/AI/EnemyReasonerControllInstaller")]
    public class EnemyReasonerControllInstaller : ScriptableObjectInstaller<EnemyReasonerControllInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyReasonerController>()
                .AsSingle();
        }
    }
}