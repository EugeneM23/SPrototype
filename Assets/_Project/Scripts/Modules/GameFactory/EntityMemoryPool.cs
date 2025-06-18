using Zenject;

namespace Gameplay
{
    public class EntityMemoryPool : MonoMemoryPool<Entity>
    {
        protected override void OnSpawned(Entity item)
        {
            base.OnSpawned(item);
            item.OnDispose += Despawn;
        }

        protected override void OnDespawned(Entity item)
        {
            base.OnDespawned(item);
            item.OnDispose -= Despawn;
        }
    }
}