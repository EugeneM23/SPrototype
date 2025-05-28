using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Gameplay
{
    public class ShootButtom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Inject] private readonly PlayerCharacterProvider _player;
        private bool _shoot;

        public void OnPointerDown(PointerEventData eventData) => _shoot = true;

        public void OnPointerUp(PointerEventData eventData) => _shoot = false;

        private void Update()
        {
            if (_shoot)
                _player.Character.Get<Player>().Shoot();
        }
    }
}