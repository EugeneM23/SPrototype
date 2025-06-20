using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class TranslateComponent : ITickable
    {
        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _root;

        private float _elapsedTime;
        private float _moveDuration;
        private Vector3 _targetPosition;
        private float _moveSpeed;
        private Transform _target;
        private float _stopingDistance;

        public void Translate(Vector3 targetPosition, float time, float speed, float stopingDistace = 0,
            Transform target = null)
        {
            _stopingDistance = stopingDistace;
            _targetPosition = targetPosition;
            _moveDuration = time;
            _moveSpeed = speed;
            _elapsedTime = 0;
            _target = target;
        }

        public void Tick()
        {
            _elapsedTime += Time.deltaTime;

            if (_target != null)
                _targetPosition = _target.position;

            var distance = Vector3.Distance(_root.transform.position, _targetPosition);
            if (distance < _stopingDistance || _elapsedTime >= _moveDuration) return;

            Vector3 currentPosition = _root.transform.position;
            Vector3 newPosition = Vector3.MoveTowards(currentPosition, _targetPosition, _moveSpeed * Time.deltaTime);
            _root.transform.position = newPosition;
        }
    }
}