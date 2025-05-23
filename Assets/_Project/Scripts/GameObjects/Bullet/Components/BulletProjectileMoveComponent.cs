using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletProjectileMoveComponent : IBulletMoveComponent, IInitializable
    {
        [Inject(Id = WeaponParameterID.BulletSpeed)]
        private float bulletSpeed;

        private readonly Entity bullet;
        private readonly PlayerCharacterProvider player;
        private readonly PlayerSpeedObserver playerSpeed;
        private readonly BezierCurveMover curveMover;

        public bool Initialized { get; set; } = false;

        public BulletProjectileMoveComponent(Entity bullet, PlayerCharacterProvider player,
            PlayerSpeedObserver playerSpeed)
        {
            this.bullet = bullet;
            this.player = player;
            this.playerSpeed = playerSpeed;
            this.curveMover = new BezierCurveMover(height: 10f); // Можно сделать параметром
        }

        public void Initialize()
        {
            bullet.Get<Bullet>().OnDispose += _ => Initialized = false;
        }

        public void Move()
        {
            if (!Initialized)
                InitTrajectory();

            Vector3 newPosition = curveMover.MoveAlongCurve(bulletSpeed);
            bullet.transform.position = newPosition;

            if (curveMover.IsComplete)
                bullet.Get<Bullet>().Dispose();
        }

        private void InitTrajectory()
        {
            Vector3 start = bullet.transform.position;
            Vector3 end = CalculatePredictedPosition();
            curveMover.Initialize(start, end);

            Initialized = true;
        }

        private Vector3 CalculatePredictedPosition()
        {
            Vector3 playerPosition = player.Character.transform.position;
            float playerSpeedValue = playerSpeed.Speed;

            Vector3 toPlayer = playerPosition - bullet.transform.position;
            float distance = toPlayer.magnitude;

            float timeToReach = distance / bulletSpeed;
            Vector3 direction = player.Character.transform.forward;

            return playerPosition + direction * playerSpeedValue * timeToReach;
        }
    }
}