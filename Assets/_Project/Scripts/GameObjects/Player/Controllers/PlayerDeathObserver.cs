using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathObserver : IInitializable, IDisposable
    {
        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _player;

        public void Initialize() => _player.Get<HealthComponent>().OnDespawn += Despawn;

        public void Dispose() => _player.Get<HealthComponent>().OnDespawn -= Despawn;

        private void Despawn(Entity entity)
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}