using Zenject;

namespace Gameplay
{
    public class TakeDamageEffectSpawnController : IInitializable
    {
        private readonly CollisionComponent _component;
        private PlayEffectComponent _playEffectComponentSpawner;

        public TakeDamageEffectSpawnController(PlayEffectComponent playEffectComponentSpawner, CollisionComponent component)
        {
            _playEffectComponentSpawner = playEffectComponentSpawner;
            _component = component;
        }

        public void Initialize()
        {
            _component.OnHit += _playEffectComponentSpawner.Play;
        }
    }
}