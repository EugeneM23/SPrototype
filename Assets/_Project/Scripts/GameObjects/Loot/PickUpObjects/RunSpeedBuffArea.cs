using System;
using DamageNumbersPro;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RunSpeedBuffArea : MonoBehaviour
    {
        [SerializeField] private int _speed;
        [SerializeField] private Entity _effectPrefab;
        [SerializeField] private DamageNumber _damageNumber;
        [Inject] private readonly GameFactory _factory;
        [Inject] private readonly DiContainer _container;

        private BuffBase _buff;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity target = other.GetComponent<Entity>();
                _buff = new BuffRunSpeed(target, _speed);
                target.Get<BuffManager>().AddBuff(_buff);

                SpawnEffects(target);
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
            Entity target = other.GetComponent<Entity>();
            target.Get<BuffManager>().RemoveBuff(_buff);
        }
    }
}