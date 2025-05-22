using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathObserver : IInitializable, IDisposable
    {
        private readonly PlayerCharacterProvider _player;

        public PlayerDeathObserver(PlayerCharacterProvider player)
        {
            _player = player;
        }

        public void Initialize() => _player.Character.Get<TakeDamageComponent>().OnDespawn += Despawn;

        public void Dispose() => _player.Character.Get<TakeDamageComponent>().OnDespawn -= Despawn;

        private void Despawn(Entity entity)
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}