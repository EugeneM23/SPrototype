using UnityEngine;

namespace Gameplay
{
    public interface IShellSpawner
    {
        public Shell Create(Vector3 position, Quaternion rotation, Vector3 shellImpulse, float power);
    }
}