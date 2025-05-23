using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameInput : ITickable
    {
        public event Action OnPause;
        public Vector3 Axis => new(SimpleInput.GetAxisRaw("Horizontal"), 0, SimpleInput.GetAxisRaw("Vertical"));

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                OnPause?.Invoke();
        }
    }
}