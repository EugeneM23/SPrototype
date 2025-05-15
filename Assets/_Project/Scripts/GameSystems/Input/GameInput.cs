using UnityEngine;

namespace Gameplay
{
    public class GameInput
    {
        public Vector3 Axis => new(SimpleInput.GetAxisRaw("Horizontal"), 0, SimpleInput.GetAxisRaw("Vertical"));
    }
}