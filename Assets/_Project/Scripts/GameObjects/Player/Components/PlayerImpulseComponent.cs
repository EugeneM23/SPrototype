using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerImpulseComponent : ITickable
    {
        [Inject] private CharacterController controller;
    
        private Vector3 impulseVelocity;
        private float currentTime;


        public void ApplyImpulse(Vector3 force, float duration)
        {
            impulseVelocity = force;
            currentTime = duration;
        }

        public void Tick()
        {
            if (currentTime > 0)
            {
                controller.Move(impulseVelocity * Time.deltaTime);
                currentTime -= Time.deltaTime;
            }
        }
    }
}