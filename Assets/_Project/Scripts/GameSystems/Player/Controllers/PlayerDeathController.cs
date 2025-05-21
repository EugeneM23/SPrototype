using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathController : IInitializable, IDisposable
    {
        private readonly PlayerCharacterProvider _player;

        public PlayerDeathController(PlayerCharacterProvider player)
        {
            _player = player;
        }

        public void Initialize() => _player.Character.Get<HealthComponentBase>().OnDespawn += Despawn;

        public void Dispose() => _player.Character.Get<HealthComponentBase>().OnDespawn -= Despawn;

        private void Despawn(HealthComponentBase obj)
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}