using DamageNumbersPro;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class HealPickUp : MonoBehaviour
    {
        [SerializeField] private int _heals;
        [SerializeField] private Entity _effectPrefab;
        [SerializeField] private DamageNumber _damageNumber;
        [Inject] private readonly GameFactory _factory;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity traget = other.GetComponent<Entity>();
                traget.Get<HealthComponent>().Heal(_heals);

                var effect = _factory.Create(_effectPrefab);
                effect.Get<EffectCaster>().CastEffect(traget.transform, 2);

                _damageNumber.Spawn(traget.transform.position + new Vector3(0, 3, 0), _heals);
                gameObject.GetComponent<Entity>().Dispose();
            }
        }
    }
}