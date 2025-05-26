using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class TestWeaponPickUp : MonoBehaviour
    {
        [SerializeField] private Entity _weapon;
        [Inject] private readonly DiContainer _container;

        private GameObject _viewMesh;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity go = other.GetComponent<Entity>();

                var inventory = go.Get<Inventory>();
                inventory.AddWeapon(_weapon);

                gameObject.SetActive(false);
            }
        }
    }
}