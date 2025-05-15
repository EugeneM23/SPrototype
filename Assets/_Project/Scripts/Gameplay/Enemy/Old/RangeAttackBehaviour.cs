using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RangeAttackBehaviour : MonoBehaviour
    {
        /*[SerializeField] private ProjectileArcMover _projectilePrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _projectileSpeed;

        [Inject] private readonly Entity _player;

        //Called by an event in animation
        public void Fire()
        {
            Vector3 targetPosition = CalculatePredictedPosition();
            ProjectileArcMover projectile = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
            projectile.Construct(_firePoint.position, targetPosition);
        }

        private Vector3 CalculatePredictedPosition()
        {
            Vector3 playerPosition = _player.transform.position;
            float playerSpeed = _player.Speed;

            Vector3 toPlayer = playerPosition - _firePoint.position;
            float distance = toPlayer.magnitude;

            float timeToReachTarget = distance / _projectileSpeed;

            Vector3 playerDirection = _player.transform.forward;

            Vector3 predictedPosition = playerPosition + playerDirection * playerSpeed * timeToReachTarget;

            return predictedPosition;
        }*/
    }
}