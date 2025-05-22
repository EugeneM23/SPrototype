using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class TranslateComponent : ITickable
    {
        private readonly Entity _root;

        private float elapsedTime;
        private float moveDuration;
        private Vector3 targetPosition;
        private float moveSpeed;
        private Transform _target;
        private float _stopingDistance;

        public TranslateComponent(Entity root)
        {
            _root = root;
        }

        public void Translate(Vector3 targetPosition, float time, float speed, float stopingDistace = 0,
            Transform target = null)
        {
            _stopingDistance = stopingDistace;
            this.targetPosition = targetPosition;
            moveDuration = time;
            moveSpeed = speed;
            elapsedTime = 0;
            _target = target;
        }

        public void Tick()
        {
            elapsedTime += Time.deltaTime;

            if (_target != null)
                targetPosition = _target.position;

            var distance = Vector3.Distance(_root.transform.position, targetPosition);
            if (distance < _stopingDistance || elapsedTime >= moveDuration) return;

            Vector3 currentPosition = _root.transform.position;
            Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
            _root.transform.position = newPosition;
        }
    }
}