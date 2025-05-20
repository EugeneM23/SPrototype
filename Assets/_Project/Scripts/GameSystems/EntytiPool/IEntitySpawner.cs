namespace Gameplay
{
    public interface IEntitySpawner
    {
        Entity Spawn(string prefabName);
        void Despawn(string prefabName, Entity entity);
    }
}