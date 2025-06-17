using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawnBodyPartComponent : IInitializable
    {
        private readonly Entity[] _bodyParts;
        private readonly GameFactory _factory;
        private readonly HealthComponent _healthComponent;

        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _entity;

        public EnemySpawnBodyPartComponent(Entity[] bodyParts, HealthComponent healthComponent, GameFactory factory)
        {
            _bodyParts = bodyParts;
            _healthComponent = healthComponent;
            _factory = factory;
        }

        public void Initialize()
        {
            _healthComponent.OnDead += SpawnBodyparts;
        }

        public void SpawnBodyparts(Entity obj)
        {
            SpawnBodyparts();
        }

        public void SpawnBodyparts()
        {
            foreach (var item in _bodyParts)
            {
                var go = _factory.Create(item);
                Vector3 force = (Random.insideUnitSphere + Vector3.up) * 20;
                go.transform.position = _entity.transform.position;
                var rb = go.GetComponent<Rigidbody>();

                rb.linearVelocity = Vector3.zero;
                rb.AddForce(force, ForceMode.Impulse);
                rb.AddTorque(force / 3, ForceMode.Impulse);
            }
        }
    }
}