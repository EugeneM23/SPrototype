using System;
using DamageNumbersPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] private Entity _weapon;
        [SerializeField] private Entity _effectPrefab;
        [SerializeField] private DamageNumber _damageNumber;
        [Inject] private readonly GameFactory _factory;

        private GameObject _viewMesh;
        private bool _IsEnable;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity target = other.GetComponent<Entity>();
                target.Get<PlayerInventory>().AddWeapon(_weapon);

                if (_effectPrefab != null)
                {
                    var effect = _factory.Create(_effectPrefab);
                    effect.Get<EffectCaster>().CastEffect(target.transform, 2);
                }

                _damageNumber.Spawn(target.transform.position + new Vector3(0, 3, 0), target.transform);
                gameObject.GetComponent<Entity>().Dispose();
            }
        }
    }
}