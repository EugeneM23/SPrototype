using DamageNumbersPro;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RunSpeedBuffArea : MonoBehaviour
    {
        [SerializeField] private int _speed;
        [SerializeField] private Entity _effectPrefab;
        [SerializeField] private Entity _uiPrefab;
        [SerializeField] private DamageNumber _damageNumber;
        [Inject] private readonly GameFactory _factory;
        [Inject] private readonly DiContainer _container;

        private BuffBase _buff;
        private Entity _target;
        private Entity go;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Entity>().TryGet<BuffManager>(out var value))
            {
                _target = other.GetComponent<Entity>();

                _buff = BuffRage
                    .Create()
                    .Target(_target)
                    .Stackable(5)
                    .Speed(15f)
                    .UI(_uiPrefab)
                    .Timed(3)
                    .Build();

                value.AddBuff(_buff);

                SpawnEffects(_target);
            }
        }

        private void SpawnEffects(Entity target)
        {
            var effect = _factory.Create(_effectPrefab);
            effect.Get<EffectCaster>().CastEffect(target.transform, 2);
            _damageNumber.Spawn(target.transform.position + new Vector3(0, 3, 0), target.transform);
            gameObject.GetComponent<Entity>().Dispose();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Entity>().TryGet<BuffManager>(out var value))
            {
                Entity target = other.GetComponent<Entity>();
            }
        }
    }
}