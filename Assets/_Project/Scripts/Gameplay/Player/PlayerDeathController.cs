using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathController : IInitializable
    {
        private readonly PlayerCharacterProvider _playerCharacterProvider;

        public PlayerDeathController(PlayerCharacterProvider playerCharacterProvider)
        {
            _playerCharacterProvider = playerCharacterProvider;
        }

        public void Initialize()
        {
            _playerCharacterProvider.Character.Get<HealthComponentBase>().OnDespawn += Despaw;
        }

        private void Despaw(HealthComponentBase obj)
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}