using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] private Entity _weapon;

        private GameObject _viewMesh;
        private bool _IsEnable;

        private void OnEnable()
        {
            _IsEnable = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                if (_IsEnable)
                {
                    _IsEnable = false;
                    Entity go = other.GetComponent<Entity>();

                    var inventory = go.Get<Inventory>();
                    inventory.AddWeapon(_weapon);

                    var entity = gameObject.GetComponent<Entity>();

                    entity.Dispose();
                }
            }
        }
    }
}