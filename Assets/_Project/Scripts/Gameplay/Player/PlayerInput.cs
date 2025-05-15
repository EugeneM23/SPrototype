using UnityEngine;

namespace Gameplay
{
    public class PlayerInput
    {
        public Vector3 Axis => new(SimpleInput.GetAxisRaw("Horizontal"), 0, SimpleInput.GetAxisRaw("Vertical"));
    }
}