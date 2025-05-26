using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class UICameraRotationComponent : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private Vector3 _offset;

        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _entity;

        private void Start() => _camera = Camera.main;

        private void Update()
        {
            Vector3 directionToCamera = _camera.transform.position - transform.position;

            directionToCamera.x = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            transform.rotation = targetRotation;
            transform.position = _entity.transform.position + _offset;
        }
    }
}