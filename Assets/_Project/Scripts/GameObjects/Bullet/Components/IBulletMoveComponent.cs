using UnityEngine;

namespace Gameplay
{
    public interface IBulletMoveComponent
    {
        void Move();
        void SetSeed(int seed);
        void SetPositionAndRotation(Vector3 position, Quaternion rotation);
    }
}