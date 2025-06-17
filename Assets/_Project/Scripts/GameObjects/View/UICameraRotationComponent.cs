using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class UICameraRotationComponent : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private bool _excludePosition;
        [Inject] private ICharacterProvider _player;

        private void Start() => _camera = Camera.main;

        private void Update()
        {
            if (_camera == null) return;
            Vector3 directionToCamera = _camera.transform.position - transform.position;

            directionToCamera.x = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            transform.rotation = targetRotation;
            if (_excludePosition) return;
            transform.position = _player.Character.transform.position + _offset;
        }
    }
}