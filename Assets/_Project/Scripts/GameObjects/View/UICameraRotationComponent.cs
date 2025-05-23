using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class UICameraRotationComponent : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private GameObject _healthBar;
        [SerializeField] private Vector3 _offset;
        [Inject] private readonly Entity _entity;

        private void Start() => _camera = Camera.main;

        private void Update()
        {
            Vector3 directionToCamera = _camera.transform.position - _healthBar.transform.position;

            directionToCamera.x = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            _healthBar.transform.rotation = targetRotation;
            _healthBar.transform.position = _entity.transform.position + _offset;
        }
    }
}