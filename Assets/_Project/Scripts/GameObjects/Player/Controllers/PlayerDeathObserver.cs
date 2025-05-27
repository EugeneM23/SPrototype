using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathObserver : IInitializable, IDisposable
    {
        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _player;

        public void Initialize() => _player.OnDispose += Despawn;

        public void Dispose() => _player.OnDispose -= Despawn;

        private void Despawn(Entity entity)
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}