using Zenject;

namespace Gameplay
{
    public class GenericEntityPool : MonoMemoryPool<Entity>
    {
        protected override void OnSpawned(Entity entity)
        {
            entity.gameObject.SetActive(true);

            if (entity.TryGetComponent(out IDisposableEntity disposable))
            {
                disposable.OnDispose += Despawn;
            }
        }

        protected override void OnDespawned(Entity entity)
        {
            entity.gameObject.SetActive(false);

            if (entity.TryGetComponent(out IDisposableEntity disposable))
            {
                disposable.OnDispose -= Despawn;
            }
        }
    }
}