using Zenject;

namespace Gameplay
{
    public class BulletPool : MemoryPool<Entity>, IBulletSpawner
    {
        public Entity Create()
        {
            return Spawn();
        }

        protected override void OnSpawned(Entity bullet)
        {
            base.OnSpawned(bullet);
            bullet.gameObject.SetActive(true);
            bullet.Get<Bullet>().OnDispose += Despawn;
        }

        protected override void OnDespawned(Entity bullet)
        {
            base.OnDespawned(bullet);
            bullet.gameObject.SetActive(false);
            bullet.Get<Bullet>().OnDispose -= Despawn;
        }
    }
}