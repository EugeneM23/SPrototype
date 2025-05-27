using Zenject;

namespace Gameplay
{
    public class EntityMemoryPool : MonoMemoryPool<Entity>
    {

        protected override void OnSpawned(Entity item)
        {
            base.OnSpawned(item);
            item.gameObject.SetActive(true);
            item.OnDispose += Despawn;
        }

        protected override void OnDespawned(Entity item)
        {
            base.OnDespawned(item);
            item.gameObject.SetActive(false);
            item.OnDispose -= Despawn;
        }
    }
}