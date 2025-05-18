using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletProjectileMoveComponent : IBulletMoveComponent
    {
        [Inject(Id = WeaponParameterID.BulletSpeed)]
        private float _bulletSpeed;

        private readonly Entity _bullet;
        private readonly PlayerCharacterProvider _player;
        private readonly PlayerSpeedObserver _playerSpeed;
        private float height = 10f;
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private float startTime;
        private float totalDistance;
        public bool Initialized = false;

        public BulletProjectileMoveComponent(Entity bullet, PlayerCharacterProvider player,
            PlayerSpeedObserver playerSpeed)
        {
            _bullet = bullet;
            _player = player;
            _playerSpeed = playerSpeed;
        }

        public void Move()
        {
            if (!Initialized)
                InitTrajectory();

            float timePassed = Time.time - startTime;
            float distanceCovered = timePassed * _bulletSpeed;
            float t = distanceCovered / totalDistance;
            t = Mathf.Clamp01(t);

            Vector3 currentPos = GetParabolaPoint(_startPosition, _endPosition, t);
            _bullet.transform.position = currentPos;

            if (t >= 3f)
                _bullet.Get<Bullet>().Dispose();
        }

        private void InitTrajectory()
        {
            _startPosition = _bullet.transform.position;
            _endPosition = CalculatePredictedPosition();
            totalDistance = Vector3.Distance(_startPosition, _endPosition);
            startTime = Time.time;
            Initialized = true;
        }

        private Vector3 GetParabolaPoint(Vector3 start, Vector3 end, float t)
        {
            Vector3 point = Vector3.Lerp(start, end, t);
            float parabolicHeight = height * t * (1 - t);
            point.y += parabolicHeight;
            return point;
        }

        private Vector3 CalculatePredictedPosition()
        {
            Vector3 playerPosition = _player.Character.transform.position;
            float playerSpeed = _playerSpeed.Speed;

            Vector3 toPlayer = playerPosition - _bullet.transform.position;
            float distance = toPlayer.magnitude;

            float timeToReachTarget = distance / _bulletSpeed;
            Vector3 playerDirection = _player.Character.transform.forward;

            return playerPosition + playerDirection * playerSpeed * timeToReachTarget;
        }
    }
}