using Zenject;

namespace Gameplay
{
    public class CameraShakeController : IInitializable
    {
        private readonly AnimationEventProvider _animationEvent;
        private readonly CameraShaker _shaker;

        public CameraShakeController(AnimationEventProvider animationEvent, CameraShaker shaker)
        {
            _animationEvent = animationEvent;
            _shaker = shaker;
        }

        public void Initialize()
        {
            _animationEvent.OnEventCall += _shaker.ShootShake;
            _animationEvent.OnEventCall += _shaker.Explosion;
            _animationEvent.OnEventCall += _shaker.SmallShake;
        }
    }
}